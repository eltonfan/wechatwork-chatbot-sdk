using Elton.WechatWork.Models;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Elton.WechatWork
{
    /// <summary>
    /// 企业微信· API 应用
    /// https://work.weixin.qq.com/api/doc/90000/90135/90236
    /// </summary>
    public partial class ApiClient : IDisposable
    {
        private static readonly ILogger log = Log.ForContext(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string corpId;
        public int AppId { get; }
        private readonly string appSecret;
        private readonly HttpClient httpClient;
        public ApiClient(string corpId, int appId, string appSecret, int timeout = 10 * 1000)
        {
            this.corpId = corpId ?? throw new ArgumentNullException(nameof(corpId));
            this.AppId = appId;
            this.appSecret = appSecret ?? throw new ArgumentNullException(nameof(appSecret));

            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(timeout)
            };
        }

        private Token token = null;

        public void Dispose()
        {
            httpClient.Dispose();
        }

        internal async Task<Models.Messages.MessageResponse> SendMessage(Models.Messages.MessageRequest message)
        {
            if (token == null || DateTime.Now.Subtract(token.Timestamp).TotalSeconds > (token.ExpiresIn / 2))
            {
                //换取新令牌
                await GetAccessToken();
            }

            var messageUrl = $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={token.AccessToken}";

            var jsonString = JsonConvert.SerializeObject(message);
            var content = new StringContent(jsonString, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            var response = await httpClient.PostAsync(messageUrl, content);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ChatbotException((int)response.StatusCode, $"Response StatusCode is '{response.StatusCode}'.");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Models.Messages.MessageResponse>(responseString);

            if (!result.IsSuccess)
            {
                throw new ChatbotException(result.ErrorCode, result.ErrorMessage);
            }
            return result;
        }

        public async Task<Token> GetAccessToken()
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={corpId}&corpsecret={appSecret}";
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ChatbotException((int)response.StatusCode, $"Response StatusCode is '{response.StatusCode}'.");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetTokenResponse>(responseString);
            if (!result.IsSuccess)
            {
                throw new ChatbotException(result.ErrorCode, result.ErrorMessage);
            }

            this.token = new Token(result.AccessToken, result.ExpiresIn ?? 0);

            return this.token;
        }
    }
}
