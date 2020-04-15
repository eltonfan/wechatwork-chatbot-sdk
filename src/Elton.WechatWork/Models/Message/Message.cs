using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Elton.WechatWork.Models.Message
{
    /// <summary>
    /// 消息实体类
    /// </summary>
    internal abstract class Message
    {
        protected Message(MessageType type)
        {
            Type = type;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("msgtype"), JsonConverter(typeof(StringEnumConverter))]
        public MessageType Type { get; }
    }
}
