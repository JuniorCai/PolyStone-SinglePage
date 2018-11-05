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

namespace PolyStone.Api.Controllers
{
    public class AuthController : AbpApiController
    {
        private string _appSecret = ConfigurationManager.AppSettings["AppSecret"];
        private string _appId = ConfigurationManager.AppSettings["AppId"];
        private string _smsAppKey = ConfigurationManager.AppSettings["SmsAppKey"];
        private string _smsAppId = ConfigurationManager.AppSettings["SmsAppId"];
        private string _smsSendUrl = ConfigurationManager.AppSettings["SmsSendUrl"];

        private readonly IAbpWebApiClient _abpWebApiClient;
        private readonly IUserAuthorizationAppService _userAuthorizationAppService;

        public AuthController(IUserAuthorizationAppService userAuthorizationAppService)
        {
            _abpWebApiClient = new AbpWebApiClient();
            _userAuthorizationAppService = userAuthorizationAppService;
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

//        public async Task<AjaxResponse> SendPhoneCode(string phoneNumber)
//        {
//            
//        }
    }



}