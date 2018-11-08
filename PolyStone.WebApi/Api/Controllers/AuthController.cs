using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Abp;
using Abp.Runtime.Session;
using Abp.Web.Models;
using Abp.WebApi.Client;
using Abp.WebApi.Controllers;
using PolyStone.Helpers;
using PolyStone.UserAuthorizations;
using PolyStone.UserAuthorizations.Dtos;
using PolyStone.Users.Dto;
using PolyStone.UserVerifies;

namespace PolyStone.Api.Controllers
{
    public class AuthController : PolyStoneApiControllerBase
    {
        private string _appSecret = ConfigurationManager.AppSettings["AppSecret"];
        private string _appId = ConfigurationManager.AppSettings["AppId"];

        private readonly IAbpWebApiClient _abpWebApiClient;
        private readonly IUserAuthorizationAppService _userAuthorizationAppService;
        private readonly IUserVerifyAppService _userVerifyAppService;

        public AuthController(IUserAuthorizationAppService userAuthorizationAppService,IUserVerifyAppService userVerifyAppService)
        {
            _abpWebApiClient = new AbpWebApiClient();
            _userAuthorizationAppService = userAuthorizationAppService;
            _userVerifyAppService = userVerifyAppService;
        }

        //GET
        [HttpGet]
        public async Task<AjaxResponse> AuthLoginCode(string code,string encryptedData,string iv)
        {
            try
            {
                string authCodeUrl =
                    $"https://api.weixin.qq.com/sns/jscode2session?appid={_appId}&secret={_appSecret}&js_code={code}&grant_type=authorization_code";

                var result = await _abpWebApiClient.GetAsync<CodeResult>(authCodeUrl);
                MiniProgramReturnResult returnResult = new MiniProgramReturnResult();
                switch (result.ErrCode)
                {
                    case 0:
                        returnResult.Code = CodeStatus.Success;
                        string randNum = Utils.GetRandom(16);
                        
                        string openId = result.OpenId;
                        break;
                    case -1:
                        returnResult.Code = CodeStatus.Failed;
                        break;
                    case 40029:
                    case 45011:
                        returnResult.Code = CodeStatus.InvalidData;

                        break;
                }

                return new AjaxResponse(result);
            }
            catch (Exception e)
            {
                return new AjaxResponse(e);
            }
        }

        private async Task<bool>  CreateUserAuthorization(string openId)
        {


            var list = await _userAuthorizationAppService.GetPagedUserAuthorizationsAsync(new GetUserAuthorizationInput(){OpenId = openId});
            if (list.TotalCount > 0)
            {
                return false;
            }
            else
            {
               // await CreateUser();
            }

            return false;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AjaxResponse> SendPhoneCode(string phoneNumber)
        {
            SmsManager smsManager=new SmsManager(phoneNumber, _userVerifyAppService);
            await smsManager.SendAuthCode();
            var sendResult = smsManager.Result;
            switch (sendResult.Code)
            {
                case 403:
                case 406:
                case 4080:
                case 4082:
                    sendResult.Msg = L("Code" + sendResult.Code);
                    break;
                default:
                    sendResult.Msg = "未知错误：" + sendResult.Code;
                    break;
            }
            return new AjaxResponse(sendResult);
        }

        [HttpPost]
        public async Task<AjaxResponse> AuthPhoneCode(SmsCheckModel model)
        {
            SmsManager smsManager = new SmsManager(model.PhoneNumber, _userVerifyAppService);
            var result = await smsManager.AuthPhoneCode(model.AuthCode);
            return new AjaxResponse(result);
        }

    }



}