using Newtonsoft.Json;

namespace Elton.WechatWork.Models.Webhooks
{
    /// <summary>
    /// 图文类型
    /// </summary>
    internal class NewsMessage : WebhookRequest
    {
        /// <summary>
        /// 图文消息，一个图文消息支持1到8条图文
        /// </summary>
        /// <param name="articles"></param>
        public NewsMessage(NewsArticle[] articles)
            : base(MessageType.News)
        {
            News = new NewsContent(articles);
        }

        [JsonConstructor]
        private NewsMessage() : base(MessageType.News) { }

        [JsonProperty("news")]
        public NewsContent News { get; private set; }

        public class NewsContent
        {
            [JsonConstructor]
            private NewsContent() { }

            public NewsContent(NewsArticle[] articles)
            {
                Articles = articles;
            }

            /// <summary>
            /// 图文消息，一个图文消息支持1到8条图文
            /// </summary>
            [JsonProperty("articles")]
            public NewsArticle[] Articles { get; private set; }
        }
    }

    public class NewsArticle
    {
        [JsonConstructor]
        private NewsArticle() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">标题，不超过128个字节，超过会自动截断</param>
        /// <param name="description">描述，不超过512个字节，超过会自动截断</param>
        /// <param name="url">点击后跳转的链接。</param>
        /// <param name="pictureUrl">图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。</param>
        public NewsArticle(string title, string url, string description = null, string pictureUrl = null)
        {
            Title = title;
            Url = url;
            Description = description;
            PictureUrl = pictureUrl;
        }

        /// <summary>
        /// 标题，不超过128个字节，超过会自动截断
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// 描述，不超过512个字节，超过会自动截断
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// 点击后跳转的链接。
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; private set; }

        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。
        /// </summary>
        [JsonProperty("picurl")]
        public string PictureUrl { get; private set; }

    }
}
