using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Elton.WechatWork
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        [EnumMember(Value = "")]
        Unknown = 0,
        /// <summary>
        /// 文本类型
        /// </summary>
        [EnumMember(Value = "text")]
        Text,
        /// <summary>
        /// Markdown 类型
        /// </summary>
        [EnumMember(Value = "markdown")]
        Markdown,
        /// <summary>
        /// 图片类型
        /// </summary>
        [EnumMember(Value = "image")]
        Image,
        /// <summary>
        /// 图文类型
        /// </summary>
        [EnumMember(Value = "news")]
        News,
    }
}
