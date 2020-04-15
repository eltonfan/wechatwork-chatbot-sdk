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
    /// 企业微信·群机器人
    /// </summary>
    public partial class ChatbotClient : IDisposable
    {
        private static readonly ILogger log = Log.ForContext(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string accessToken;
        private readonly string webHookUrl;
        private readonly HttpClient httpClient;
        public ChatbotClient(string accessToken, int timeout = 10 * 1000)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException("Parameter accessToken cannot be null or empty.", "accessToken");
            }

            this.accessToken = accessToken;
            webHookUrl = $"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={accessToken}";

            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(timeout)
            };
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        internal async Task Send(Message message)
        {
            var jsonString = JsonConvert.SerializeObject(message);
            var content = new StringContent(jsonString, Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            var response = await httpClient.PostAsync(webHookUrl, content);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ChatbotException((int)response.StatusCode, $"Response StatusCode is '{response.StatusCode}'.");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SendResponse>(responseString);

            if (!result.IsSuccess)
            {
                throw new ChatbotException(result.ErrorCode, result.ErrorMessage);
            }
        }

        /// <summary>
        /// 文本类型
        /// </summary>
        /// <param name="content">文本内容，最长不超过2048个字节，必须是utf8编码</param>
        /// <param name="mentionedList">userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list</param>
        /// <param name="mentionedMobileList">手机号列表，提醒手机号对应的群成员(@某个成员)，@all表示提醒所有人</param>
        /// <returns></returns>
        public async Task SendText(string content, string[] mentionedList = null, string[] mentionedMobileList = null)
        {
            var message = new TextMessage(content, mentionedList, mentionedMobileList);
            await Send(message);
        }

        /// <summary>
        /// Markdown 类型
        /// </summary>
        /// <param name="content">markdown内容，最长不超过4096个字节，必须是utf8编码</param>
        /// <returns></returns>
        public async Task SendMarkdown(string content)
        {
            var message = new MarkdownMessage(content);
            await Send(message);
        }

        /// <summary>
        /// 图片类型
        /// </summary>
        /// <param name="image">图片（base64编码前）最大不能超过2M，支持JPG,PNG格式</param>
        /// <returns></returns>
        public async Task SendImage(byte[] image)
        {
            var base64 = image.ToBase64();
            string hash;
            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(image).ToBinHex();
            }
            var message = new ImageMessage(base64, hash);
            await Send(message);
        }

        /// <summary>
        /// 图文类型
        /// </summary>
        /// <param name="articles">图文消息，一个图文消息支持1到8条图文</param>
        /// <returns></returns>
        public async Task SendNews(params NewsArticle[] articles)
        {
            var message = new NewsMessage(articles);
            await Send(message);
        }

        /// <summary>
        /// 图文类型
        /// </summary>
        /// <param name="title">标题，不超过128个字节，超过会自动截断</param>
        /// <param name="description">描述，不超过512个字节，超过会自动截断</param>
        /// <param name="url">点击后跳转的链接。</param>
        /// <param name="pictureUrl">图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。</param>
        /// <returns></returns>
        public async Task SendNews(string title, string url, string description = null, string pictureUrl = null)
        {
            var message = new NewsMessage(new[] { new NewsArticle(title, url, description, pictureUrl) });
            await Send(message);
        }
    }
}
