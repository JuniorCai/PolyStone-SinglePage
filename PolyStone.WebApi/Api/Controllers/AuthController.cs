using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Abp;
using Abp.Web.Models;
using Abp.WebApi.Client;
using Abp.WebApi.Controllers;
using PolyStone.Helpers;

namespace PolyStone.Api.Controllers
{
    public class AuthController : AbpApiController
    {
        private string _appSecret = ConfigurationManager.AppSettings["AppSecret"];
        private string _appId = ConfigurationManager.AppSettings["AppId"];
        private readonly IAbpWebApiClient _abpWebApiClient;

        public AuthController()
        {
            _abpWebApiClient = new AbpWebApiClient();
        }

        //GET
        [HttpGet]
        public async Task<AjaxResponse> AuthLoginCode(string code)
        {
            try
            {
                string authCodeUrl =
                    $"https://api.weixin.qq.com/sns/jscode2session?appid={_appId}&secret={_appSecret}&js_code={code}&grant_type=authorization_code";

                var result = await _abpWebApiClient.GetAsync<CodeResult>(authCodeUrl);
                return new AjaxResponse(result);
            }
            catch (Exception e)
            {
                return new AjaxResponse(e);
            }
        }
        
    }

    public class CodeResult
    {
        public string session_key { get; set; }
        public string  openid { get; set; }
    }

    public class AbpWebApiClientTest : AbpWebApiClient
    {
        public override async Task<TResult> PostAsync<TResult>(string url, object input, int? timeout = null)
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            {
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = timeout.HasValue ? TimeSpan.FromMilliseconds(timeout.Value) : Timeout;


                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    foreach (var header in RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }

                    using (var requestContent = new StringContent("", Encoding.UTF8, "application/json"))
                    {
                    

                        using (var response = await client.PostAsync(url, requestContent))
                        {
                            SetResponseHeaders(response);

                            if (!response.IsSuccessStatusCode)
                            {
                                throw new AbpException("Could not made request to " + url + "! StatusCode: " + response.StatusCode + ", ReasonPhrase: " + response.ReasonPhrase);
                            }

                            var ajaxResponse = await response.Content.ReadAsStringAsync();
                            var tr = new object();
                            return (TResult) tr;
                        }
                    }
                }
            }
        }

        private void SetResponseHeaders(HttpResponseMessage response)
        {
            ResponseHeaders.Clear();
            foreach (var header in response.Headers)
            {
                foreach (var headerValue in header.Value)
                {
                    ResponseHeaders.Add(new NameValue(header.Key, headerValue));
                }
            }
        }


    }
}