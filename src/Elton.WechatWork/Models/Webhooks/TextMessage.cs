using Newtonsoft.Json;
using System;

namespace Elton.WechatWork.Models.Webhooks
{
    /// <summary>
    /// 文本类型
    /// </summary>
    internal class TextMessage : WebhookRequest
    {
        public TextMessage(string content, string[] mentionedList = null, string[] mentionedMobileList = null)
            : base(MessageType.Text)
        {
            Text = new TextContent(content, mentionedList, mentionedMobileList);
        }

        [JsonConstructor]
        private TextMessage() : base(MessageType.Text) { }

        [JsonProperty("text")]
        public TextContent Text { get; private set; }

        public class TextContent
        {
            [JsonConstructor]
            private TextContent() { }

            public TextContent(string content, string[] mentionedList = null, string[] mentionedMobileList = null)
            {
                Content = content ?? throw new ArgumentNullException(nameof(content));
                MentionedList = mentionedList;
                MentionedMobileList = mentionedMobileList;
            }

            /// <summary>
            /// 文本内容，最长不超过2048个字节，必须是utf8编码
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; private set; }

            /// <summary>
            /// userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list
            /// </summary>
            [JsonProperty("mentioned_list")]
            public string[] MentionedList { get; private set; }

            /// <summary>
            /// 手机号列表，提醒手机号对应的群成员(@某个成员)，@all表示提醒所有人
            /// </summary>
            [JsonProperty("mentioned_mobile_list")]
            public string[] MentionedMobileList { get; private set; }
        }
    }
}
