using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp;
using Abp.Extensions;
using Abp.WebApi.Client;
using Newtonsoft.Json;

namespace PolyStone.Helpers
{
    public static class AbpWebApiClientExtension
    {
        public static async Task<TResult> GetAsync<TResult>(this IAbpWebApiClient apiClient,string url, int? timeout = null) where TResult : class
        {
            var result = JsonString2Object<TResult>(await PostUrlAndGetResult(apiClient, url, timeout));

            return result;

        }

        public static async Task<string> GetAsync(this IAbpWebApiClient apiClient, string url, int? timeout = null)
        {
            return await PostUrlAndGetResult(apiClient, url, timeout);
        }

        private static async Task<string> PostUrlAndGetResult(IAbpWebApiClient apiClient, string url, int? timeout = null)
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            {
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = timeout.HasValue ? TimeSpan.FromMilliseconds(timeout.Value) : apiClient.Timeout;

                    if (!apiClient.BaseUrl.IsNullOrEmpty())
                    {
                        client.BaseAddress = new Uri(apiClient.BaseUrl);
                    }

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    foreach (var header in apiClient.RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }

                    using (var requestContent = new StringContent("", Encoding.UTF8, "application/json"))
                    {
                        foreach (var cookie in apiClient.Cookies)
                        {
                            if (!apiClient.BaseUrl.IsNullOrEmpty())
                            {
                                cookieContainer.Add(new Uri(apiClient.BaseUrl), cookie);
                            }
                            else
                            {
                                cookieContainer.Add(cookie);
                            }
                        }

                        using (var response = await client.PostAsync(url, requestContent))
                        {
                            apiClient.ResponseHeaders.Clear();
                            foreach (var header in response.Headers)
                            {
                                foreach (var headerValue in header.Value)
                                {
                                    apiClient.ResponseHeaders.Add(new NameValue(header.Key, headerValue));
                                }
                            }

                            if (!response.IsSuccessStatusCode)
                            {
                                throw new AbpException("Could not made request to " + url + "! StatusCode: " + response.StatusCode + ", ReasonPhrase: " + response.ReasonPhrase);
                            }

                            var result = await response.Content.ReadAsStringAsync();

                            return result;
                        }
                    }
                }
            }
        }

        private static TObj JsonString2Object<TObj>(string str)
        {
            return JsonConvert.DeserializeObject<TObj>(str);
        }
    }

    public class CodeResult
    {
        public string Session_Key { get; set; }
        public string OpenId { get; set; }

        public string UnionId { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }
    }

}
