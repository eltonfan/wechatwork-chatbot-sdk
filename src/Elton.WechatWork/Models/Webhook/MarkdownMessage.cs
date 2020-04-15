using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Elton.WechatWork.Models.Webhook
{
    /// <summary>
    /// Markdown 类型
    /// </summary>
    internal class MarkdownMessage : Message
    {
        [JsonConstructor]
        public MarkdownMessage() : base(MessageType.Markdown) { }

        public MarkdownMessage(string content)
            : base(MessageType.Markdown)
        {
            Markdown = new MarkdownContent(content);
        }

        [JsonProperty("markdown")]
        public MarkdownContent Markdown { get; set; }

        public class MarkdownContent
        {
            [JsonConstructor]
            private MarkdownContent() { }

            public MarkdownContent(string content)
            {
                Content = content ?? throw new ArgumentNullException(nameof(content));
            }

            /// <summary>
            /// markdown内容，最长不超过4096个字节，必须是utf8编码
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; private set; }
        }
    }
}
