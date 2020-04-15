using Newtonsoft.Json;
using System;

namespace Elton.WechatWork.Models.Messages
{
    /// <summary>
    /// 文本类型
    /// </summary>
    internal class TextMessage : MessageRequest
    {
        [JsonConstructor]
        public TextMessage() : base(MessageType.Text) { }

        /// <summary>
        /// 指定接收消息的成员，成员ID列表（多个接收者用‘|’分隔，最多支持1000个）。
        /// 特殊情况：指定为”@all”，则向该企业应用的全部成员发送
        /// </summary>
        [JsonProperty("touser")]
        public string touser { get; set; }

        /// <summary>
        /// 指定接收消息的部门，部门ID列表，多个接收者用‘|’分隔，最多支持100个。
        /// 当touser为”@all”时忽略本参数
        /// </summary>
        [JsonProperty("toparty")]
        public string toparty { get; set; }

        /// <summary>
        /// 指定接收消息的标签，标签ID列表，多个接收者用‘|’分隔，最多支持100个。
        /// 当touser为”@all”时忽略本参数
        /// </summary>
        [JsonProperty("totag")]
        public string totag { get; set; }

        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        [JsonProperty("msgtype")]
        public string msgtype { get; } = "text";

        /// <summary>
        /// 企业应用的id，整型。企业内部开发，可在应用的设置页面查看；第三方服务商，可通过接口 获取企业授权信息 获取该参数值
        /// </summary>
        [JsonProperty("agentid")]
        public int agentid { get; set; }

        [JsonProperty("text")]
        public TextContent Text { get; } = new TextContent();

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty("safe")]
        public int safe { get; private set; }

        /// <summary>
        /// 表示是否开启id转译，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty("enable_id_trans")]
        public int enable_id_trans { get; private set; }

        /// <summary>
        /// 表示是否开启重复消息检查，0表示否，1表示是，默认0
        /// </summary>
        [JsonProperty("enable_duplicate_check")]
        public int enable_duplicate_check { get; private set; }

        /// <summary>
        /// 表示是否重复消息检查的时间间隔，默认1800s，最大不超过4小时
        /// </summary>
        [JsonProperty("duplicate_check_interval")]
        public int duplicate_check_interval { get; private set; }

        public class TextContent
        {
            [JsonConstructor]
            public TextContent() { }

            /// <summary>
            /// 消息内容，最长不超过2048个字节，超过将截断（支持id转译）
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }
}
