using Newtonsoft.Json;

namespace Elton.WechatWork.Models.Webhook
{
    /// <summary>
    /// 图片类型
    /// 
    /// 注：图片（base64编码前）最大不能超过2M，支持JPG,PNG格式
    /// </summary>
    internal class ImageMessage : Message
    {
        [JsonConstructor]
        private ImageMessage() : base(MessageType.Image) { }

        public ImageMessage(string base64, string md5)
            : base(MessageType.Image)
        {
            Image = new ImageContent(base64, md5);
        }

        [JsonProperty("image")]
        public ImageContent Image { get; private set; }

        public class ImageContent
        {
            public ImageContent(string base64, string hash)
            {
                Base64 = base64;
                Hash = hash;
            }

            [JsonConstructor]
            private ImageContent() { }

            /// <summary>
            /// 图片内容的base64编码
            /// </summary>
            [JsonProperty("base64")]
            public string Base64 { get; set; }

            /// <summary>
            /// 图片内容（base64编码前）的md5值
            /// </summary>
            [JsonProperty("md5")]
            public string Hash { get; set; }
        }
    }
}
