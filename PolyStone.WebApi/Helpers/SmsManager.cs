using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string AppId { get; set; }

        public string AppKey { get; set; }

        public int ResultCode { get; set; }

        public SmsResult Result { get; set; }

        private string  _postUrl= ConfigurationManager.AppSettings["SmsSendUrl"];


    /**
     * 根据手机号码构造短信管理器
     * @param IVerifyCodeService $verifyCodeService
     * @param $mobile
     * @param $ip
     */
    public function __construct(IVerifyCodeService $verifyCodeService,$mobile,$ip)
        {
        $this->VerifyCodeService = $verifyCodeService;

        $this->Mobile = $mobile;
        $this->Email = '';
        $this->Code = '';
        $this->Ip = $ip;
        $this->Type = VerifyType::Mobile;
        $this->Account = env("SMS_ACCOUNT", "");
        $this->AppKey = env("SMS_APIKEY", "");
        $this->State = config("app.SendSmsSwitch.State");
        }


        /**
         * 请求短信接口发送短信并接受状态反馈
         * @param string $url 请求网址
         * @param bool $params 请求参数
         * @param int $isPost 请求方式
         * @param int $https https协议
         * @return bool|mixed
         */
        protected function SendPost($url, $params = false, $isPost = 0, $https = 0)
        {
        $httpInfo = array();
        $ch = curl_init();
            curl_setopt($ch, CURLOPT_HTTP_VERSION, CURL_HTTP_VERSION_1_1);
            curl_setopt($ch, CURLOPT_USERAGENT, 'Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36');
            curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 30);
            curl_setopt($ch, CURLOPT_TIMEOUT, 30);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
            if ($https) {
                curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, FALSE); // 对认证证书来源的检查
                curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, FALSE); // 从证书中检查SSL加密算法是否存在
            }
            if ($isPost) {
                curl_setopt($ch, CURLOPT_POST, true);
                curl_setopt($ch, CURLOPT_POSTFIELDS, $params);
                curl_setopt($ch, CURLOPT_URL, $url);
            } else {
                if ($params) {
                    if (is_array($params))
                    {
                    $params = http_build_query($params);
                    }
                    curl_setopt($ch, CURLOPT_URL, ($url. '?'. $params));
                } else {
                    curl_setopt($ch, CURLOPT_URL, $url);
                }
            }

        $response = json_decode(curl_exec($ch));

            if ($response->code != 2) {
                //echo "cURL Error: " . curl_error($ch);
                return -1;
            }
        $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
        $httpInfo = array_merge($httpInfo, curl_getinfo($ch));
            curl_close($ch);
            return $response->code;
        }

        /**
         * 获取随机验证码
         * @param int $length
         * @param int $numeric
         * @return string
         */
        protected function GetRandomCode($length = 6, $numeric = 0)
        {
            PHP_VERSION < '4.2.0' && mt_srand((double)microtime() * 1000000);
            if ($numeric) {
            $hash = sprintf('%0'.$length.'d', mt_rand(0, pow(10, $length) - 1));
            } else {
            $hash = '';
            $chars = 'ABCDEFGHJKLMNPQRSTUVWXYZ23456789abcdefghjkmnpqrstuvwxyz';
            $max = strlen($chars) - 1;
                for ($i = 0; $i < $length; $i++) {
                $hash.= $chars[mt_rand(0, $max)];
                }
            }
            return $hash;
        }

        /**
         * 发送验证码短信
         * @return bool
         */
        function SendMobileCode()
        {
        $this->ClearMobilePreVerify();
            //如果短信关闭，则直接返回true
            //        if($this->State==smsSwitchState::OFF)
            //        {
            //            return true;
            //        }

            //检查发送次数是否超出
            if (!$this->CheckIpSendOutNumber() && !$this->CheckMobileSendOutNumber())
        {
            //短信接口地址
            $target = "http://106.ihuyi.cn/webservice/sms.php?method=Submit";

            //获取验证码,当有图片验证码时使用
            //$send_code = $_POST['send_code'];

            //生成的随机数
            $mobile_code = $this->GetRandomCode(4, 1);
                if (empty($this->Mobile))
                {
                    exit('手机号码不能为空');
                }
            //防用户恶意请求
            //if(empty($_SESSION['send_code']) or $send_code!=$_SESSION['send_code']){
            //    exit('请求超时，请刷新页面后重试');
            //}

             $post_data = "account=".$this->Account."&password=".$this->AppKey."&mobile=".$this->Mobile
                 ."&content=".rawurlencode("您的验证码是：".$mobile_code."。请不要把验证码泄露给其他人。")
                ."&format=json";

            //$post_data=['account'=>$this->Account,'password'=>$this->AppKey,'mobile'=>$this->Mobile,'content'=>$content,'format'=>'json'];

            //判断返回值是否成功
            $codeResponse = 2;//$this->SendPost($target,$post_data,true,false);

                if ($codeResponse == 2)
            {
                $this->Code = $mobile_code;
                    //将验证码存入数据库
                    if ($this->StoreVerifyCode()->id > 0)
                {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        /**
         * 将与手机号码关联的未使用的验证码信息置为无效
         */
        protected function ClearMobilePreVerify()
        {
        $filterArray = [];
        $updateArray = [];

            array_push($filterArray,["mobile", "=",$this->Mobile]);
            array_push($filterArray,["status", "=", VerifyCodeStatusEnum::Pending]);

        $updateArray = array_add($updateArray, "status", VerifyCodeStatusEnum::Invalid);

        $this->VerifyCodeService->ToggleVerifyStatusByMobile($filterArray,$updateArray);
        }

        /**
         * 保存验证码短信
         * @return 返回保存成功的验证码对象，不成功返回null
         */
        protected function StoreVerifyCode()
        {
        $verifyModel = new UserVerify();
        $verifyModel->typeId = $this->Type;
        $verifyModel->mobile = $this->Mobile;
        $verifyModel->email =$this->Email;
        $verifyModel->verifyCode = $this->Code;
        $verifyModel->ip = $this->Ip;
        $verifyModel->status = VerifyCodeStatusEnum::Pending;

            return $this->VerifyCodeService->CreateVerifyCode($verifyModel);
        }

        /**
         * 检查是否为恶意点击发送短信
         */
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

        protected function CheckMobileSendOutNumber()
        {
        //检查同一个手机号只能发5条
        $filterArray = [];
            array_push($filterArray,['mobile', '=',$this->Mobile]);
            array_push($filterArray,['created_at', '>=', Carbon::today()]);
            array_push($filterArray,['created_at', '<', Carbon::tomorrow()]);

        $results = $this->VerifyCodeService->GetResultsByFilter($filterArray);
            if (count($results) < 5)
            {
                return false;
            }
            return true;
        }

        /**
         * 验证短信验证码
         * @param $receivedCode
         * @return bool
         */
        function AuthMobileCode($receivedCode)
        {
        $expirationTime = Carbon::now()->subMinutes(30);
        $existCode = $this->VerifyCodeService->CheckMobileVerifyCode($this->Mobile,$receivedCode,$expirationTime);
            if ($existCode != null)
        {
            //置验证码状态
            $existCode->status = VerifyCodeStatusEnum::Invalid;
            $this->VerifyCodeService->SaveVerify($existCode);

                return true;
            }
            return false;
        }
    }
}
