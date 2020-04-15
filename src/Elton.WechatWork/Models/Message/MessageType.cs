using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Elton.WechatWork.Models.Message
{
    /// <summary>
    /// 应用消息类型
    /// </summary>
    public enum MessageType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        [EnumMember(Value = "")]
        Unknown = 0,
        /// <summary>
        /// 文本消息
        /// </summary>
        [EnumMember(Value = "text")]
        Text,
        /// <summary>
        /// 图片消息
        /// </summary>
        [EnumMember(Value = "image")]
        Image,
        /// <summary>
        /// 语音消息
        /// </summary>
        [EnumMember(Value = "voice")]
        Voice,
        /// <summary>
        /// 视频消息
        /// </summary>
        [EnumMember(Value = "video")]
        Video,
        /// <summary>
        /// 文件消息
        /// </summary>
        [EnumMember(Value = "file")]
        File,
        /// <summary>
        /// 文本卡片消息
        /// </summary>
        [EnumMember(Value = "textcard")]
        TextCard,
        /// <summary>
        /// 图文消息
        /// </summary>
        [EnumMember(Value = "news")]
        News,
        /// <summary>
        /// 图文消息（mpnews）
        /// </summary>
        [EnumMember(Value = "mpnews")]
        MpNews,
        /// <summary>
        /// Markdown 消息
        /// </summary>
        [EnumMember(Value = "markdown")]
        Markdown,
        /// <summary>
        /// 小程序通知消息
        /// </summary>
        [EnumMember(Value = "miniprogram_notice")]
        MiniProgramNotice,
        /// <summary>
        /// 任务卡片消息
        /// </summary>
        [EnumMember(Value = "taskcard")]
        TaskCard,
    }
}
