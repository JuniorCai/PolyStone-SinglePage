using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.WebApi.Client;
using PolyStone.CustomDomain.UserVerifies;
using PolyStone.UserVerifies;
using PolyStone.UserVerifies.Dtos;

namespace PolyStone.Helpers
{
    public class SmsCheckModel
    {
        public string PhoneNumber { get; set; }

        public string AuthCode { get; set; }
    }

    public class SmsResult
    {
        public int Code { get; set; }

        public string SmsId { get; set; }

        public string Msg { get; set; }
    }
    public class SmsManager
    {
        public string PhoneNumber { get; set; }

        public string AuthCode { get; set; }

        public string RequestIp { get; set; }

        public SmsResult Result { get; set; }

        private string _smsAppId = ConfigurationManager.AppSettings["SmsAppId"];
        private string _smsAppKey = ConfigurationManager.AppSettings["SmsAppKey"];
        private string _smsSendUrl = ConfigurationManager.AppSettings["SmsSendUrl"];
        private int _periodMin = int.Parse(ConfigurationManager.AppSettings["SmsCodePeriod"]);

        private IUserVerifyAppService _userVerifyAppService;
        private readonly IAbpWebApiClient _abpWebApiClient = new AbpWebApiClient();

        /**
         * 根据手机号码构造短信管理器
         * @param IVerifyCodeService $verifyCodeService
         * @param $mobile
         * @param $ip
         */
        public SmsManager(string phoneNumber,IUserVerifyAppService userVerifyAppService)
        {
            PhoneNumber = phoneNumber;
            _smsSendUrl += "&account={0}&password={1}&mobile={2}&content=您的验证码是：{3}。请不要把验证码泄露给其他人。&format=json";
            _userVerifyAppService = userVerifyAppService;
        }

        /**
         * 请求短信接口发送短信并接受状态反馈
         * @param string $url 请求网址
         * @param bool $params 请求参数
         * @param int $isPost 请求方式
         * @param int $https https协议
         * @return bool|mixed
         */
        protected async Task<SmsResult> SendPost(bool isPost = false)
        {
            var result = await _abpWebApiClient.GetAsync<SmsResult>(_smsSendUrl);
            Result = result;
            return result;
        }

        /**
         * 获取随机验证码
         * @param int $length
         * @param int $numeric
         * @return string
         */
        protected string GetRandomCode(int codeLength = 6, bool isNumeric = true)
        {
            string authCode = "";
            if (isNumeric)
            {
                authCode = GetRandomInt(codeLength);
            }
            else
            {
                authCode = GetRandomIntMixChar(codeLength);
            }

            AuthCode = authCode;
            return authCode;
        }

        /// <summary>
        /// 数字验证码
        /// </summary>
        /// <param name="codeLength">验证码的位数‘n’</param>
        /// <returns>返回‘n’位验证码的字符串</returns>
        private String GetRandomInt(int codeLength)
        {
            Random random = new Random();
            StringBuilder sbmin = new StringBuilder();
            StringBuilder sbmax = new StringBuilder();
            for (int i = 0; i < codeLength; i++)
            {
                sbmin.Append("1");
                sbmax.Append("9");
            }
            return random.Next(Convert.ToInt32(sbmin.ToString()), Convert.ToInt32(sbmax.ToString())).ToString();
        }

        private String GetRandomIntMixChar(int codeLength)
        {
            string pattern = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            int randomMax = pattern.Length - 1;
            StringBuilder codeBuilder = new StringBuilder();
            Random codeRandom = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                codeBuilder.Append(pattern[codeRandom.Next(randomMax)]);
                System.Threading.Thread.Sleep(100);
            }
            return codeBuilder.ToString();
        }
        /**
         * 发送验证码短信
         * @return bool
         */
        public async Task SendAuthCode()
        {
            SetCodeVerifyStatusInvalid();
            //如果短信关闭，则直接返回true
            //        if($this->State==smsSwitchState::OFF)
            //        {
            //            return true;
            //        }

            //检查发送次数是否超出
            if (!CheckIpSendOutLimit() && !CheckMobileSendOutLimit())
            {
                //短信接口地址
                //$target = "http://106.ihuyi.cn/webservice/sms.php?method=Submit";

                //获取验证码,当有图片验证码时使用
                //$send_code = $_POST['send_code'];

                //生成的随机数
                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    GetRandomCode(4, true);
                }
                else
                {
                    Result = new SmsResult()
                    {
                        Code = 403,
                        Msg = "手机号不能为空",
                        SmsId = "0"
                    };
                    return ;
                }

                //防用户恶意请求
                //if(empty($_SESSION['send_code']) or $send_code!=$_SESSION['send_code']){
                //    exit('请求超时，请刷新页面后重试');
                //}

                _smsSendUrl = string.Format(_smsSendUrl, _smsAppId, _smsAppKey, PhoneNumber, AuthCode);


                //判断返回值是否成功
                var sendResult = await SendPost(false);
                if (sendResult.Code == 2)
                {
                    await StoreVerifyCode();
                }
            }
        }

        /**
         * 将与手机号码关联的未使用的验证码信息置为无效
         */
        protected void SetCodeVerifyStatusInvalid()
        {
            _userVerifyAppService.SetPhoneCodeVerifyStatus(PhoneNumber, CodeVerifyStatus.Invalid);
        }

        protected void SetCodeVerifyStatusSuccess()
        {
            _userVerifyAppService.SetPhoneCodeVerifyStatus(PhoneNumber, CodeVerifyStatus.Success);

        }

        /**
         * 保存验证码短信
         * @return 返回保存成功的验证码对象，不成功返回null
         */
        protected async Task StoreVerifyCode()
        {
            UserVerifyEditDto editDto = new UserVerifyEditDto();

            editDto.Code = AuthCode;
            editDto.PhoneNumber = PhoneNumber;
            editDto.Ip = RequestIp;
            editDto.ExpirationTime = DateTime.Now.AddMinutes(_periodMin);
            editDto.CodeType = CodeType.Mobile;
            editDto.VerifyStatus = CodeVerifyStatus.Pending;
            await _userVerifyAppService.CreateOrUpdateUserVerifyAsync(new CreateOrUpdateUserVerifyInput(){UserVerifyEditDto = editDto });

        }
        
        /**
         * 检查是否为恶意点击发送短信
         */
        protected bool CheckIpSendOutLimit()
        {
            //检查同一个IP每天最多只能发5条
            GetUserVerifyInput filterInput = new GetUserVerifyInput()
            {
                CreationTime = DateTime.Today,
                ExpirationTime = DateTime.Today.AddDays(1),
                Ip = RequestIp
            };
            var list = _userVerifyAppService.GetPagedUserVerifysAsync(filterInput);
            return list.Result.TotalCount > 5;
        }

        protected bool CheckMobileSendOutLimit()
        {
            //检查同一个手机号只能发5条
            GetUserVerifyInput filterInput = new GetUserVerifyInput()
            {
                CreationTime = DateTime.Today,
                ExpirationTime = DateTime.Today.AddDays(1),
                PhoneNumber = PhoneNumber
            };
            var list = _userVerifyAppService.GetPagedUserVerifysAsync(filterInput);
            return list.Result.TotalCount > 5;
        }

        /**
         * 验证短信验证码
         * @param $receivedCode
         * @return bool
         */
        public async Task<bool> AuthPhoneCode(string receivedCode)
        {
            if (string.IsNullOrEmpty(PhoneNumber))
                return false;
            bool result = await _userVerifyAppService.CheckPhoneAuthCode(PhoneNumber, receivedCode);
            return result;
        }
    }
}
