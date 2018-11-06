using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyStone.UserVerifies;
using PolyStone.UserVerifies.Dtos;

namespace PolyStone.Helpers
{
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

        private string  _postUrl= ConfigurationManager.AppSettings["SmsSendUrl"];
        private string _smsAppId = ConfigurationManager.AppSettings["SmsAppId"];
        private string _smsSendUrl = ConfigurationManager.AppSettings["SmsSendUrl"];

        private IUserVerifyAppService _userVerifyAppService;

        /**
         * 根据手机号码构造短信管理器
         * @param IVerifyCodeService $verifyCodeService
         * @param $mobile
         * @param $ip
         */
        public SmsManager(string phoneNumber,IUserVerifyAppService userVerifyAppService)
        {
            PhoneNumber = phoneNumber;
            _smsSendUrl += "&account={0}&password={1}&mobile={2}&content=您的验证码是：{3}。请不要把验证码泄露给其他人。";
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
//        protected async Task<string> SendPost(bool isPost = false)
//        {
//        
//        }

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
            return authCode;
        }

        /// <summary>
        /// 数字验证码
        /// </summary>
        /// <param name="codeLength">验证码的位数‘n’</param>
        /// <returns>返回‘n’位验证码的字符串</returns>
        private static String GetRandomInt(int codeLength)
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

        private static String GetRandomIntMixChar(int codeLength)
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
//        function SendMobileCode()
//        {
//        $this->ClearMobilePreVerify();
//            //如果短信关闭，则直接返回true
//            //        if($this->State==smsSwitchState::OFF)
//            //        {
//            //            return true;
//            //        }
//
//            //检查发送次数是否超出
//            if (!$this->CheckIpSendOutNumber() && !$this->CheckMobileSendOutNumber())
//        {
//            //短信接口地址
//            $target = "http://106.ihuyi.cn/webservice/sms.php?method=Submit";
//
//            //获取验证码,当有图片验证码时使用
//            //$send_code = $_POST['send_code'];
//
//            //生成的随机数
//            $mobile_code = $this->GetRandomCode(4, 1);
//                if (empty($this->Mobile))
//                {
//                    exit('手机号码不能为空');
//                }
//            //防用户恶意请求
//            //if(empty($_SESSION['send_code']) or $send_code!=$_SESSION['send_code']){
//            //    exit('请求超时，请刷新页面后重试');
//            //}
//
//             $post_data = "account=".$this->Account."&password=".$this->AppKey."&mobile=".$this->Mobile
//                 ."&content=".rawurlencode("您的验证码是：".$mobile_code."。请不要把验证码泄露给其他人。")
//                ."&format=json";
//
//            //$post_data=['account'=>$this->Account,'password'=>$this->AppKey,'mobile'=>$this->Mobile,'content'=>$content,'format'=>'json'];
//
//            //判断返回值是否成功
//            $codeResponse = 2;//$this->SendPost($target,$post_data,true,false);
//
//                if ($codeResponse == 2)
//            {
//                $this->Code = $mobile_code;
//                    //将验证码存入数据库
//                    if ($this->StoreVerifyCode()->id > 0)
//                {
//                        return true;
//                    }
//                }
//                return false;
//            }
//            return false;
//        }
//
//        /**
//         * 将与手机号码关联的未使用的验证码信息置为无效
//         */
//        protected function ClearMobilePreVerify()
//        {
//        $filterArray = [];
//        $updateArray = [];
//
//            array_push($filterArray,["mobile", "=",$this->Mobile]);
//            array_push($filterArray,["status", "=", VerifyCodeStatusEnum::Pending]);
//
//        $updateArray = array_add($updateArray, "status", VerifyCodeStatusEnum::Invalid);
//
//        $this->VerifyCodeService->ToggleVerifyStatusByMobile($filterArray,$updateArray);
//        }
//
//        /**
//         * 保存验证码短信
//         * @return 返回保存成功的验证码对象，不成功返回null
//         */
//        protected function StoreVerifyCode()
//        {
//        $verifyModel = new UserVerify();
//        $verifyModel->typeId = $this->Type;
//        $verifyModel->mobile = $this->Mobile;
//        $verifyModel->email =$this->Email;
//        $verifyModel->verifyCode = $this->Code;
//        $verifyModel->ip = $this->Ip;
//        $verifyModel->status = VerifyCodeStatusEnum::Pending;
//
//            return $this->VerifyCodeService->CreateVerifyCode($verifyModel);
//        }
//
//        /**
//         * 检查是否为恶意点击发送短信
//         */
        protected function CheckIpSendOutNumber()
        {
            //检查同一个IP每天最多只能发5条
        $filterArray = [];
            array_push($filterArray,['ip', '=',$this->Ip]);
            array_push($filterArray,['created_at', '>=', Carbon::today()]);
            array_push($filterArray,['created_at', '<', Carbon::tomorrow()]);

        $results = $this->VerifyCodeService->GetResultsByFilter($filterArray);
            if (count($results) < 5)
            {
                return false;
            }
            return true;
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
//
//        /**
//         * 验证短信验证码
//         * @param $receivedCode
//         * @return bool
//         */
//        function AuthMobileCode($receivedCode)
//        {
//        $expirationTime = Carbon::now()->subMinutes(30);
//        $existCode = $this->VerifyCodeService->CheckMobileVerifyCode($this->Mobile,$receivedCode,$expirationTime);
//            if ($existCode != null)
//        {
//            //置验证码状态
//            $existCode->status = VerifyCodeStatusEnum::Invalid;
//            $this->VerifyCodeService->SaveVerify($existCode);
//
//                return true;
//            }
//            return false;
//        }
    }
}
