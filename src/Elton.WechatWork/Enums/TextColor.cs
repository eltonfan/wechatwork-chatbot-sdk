using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Elton.WechatWork
{
    public enum TextColor
    {
        /// <summary>
        /// 绿色
        /// </summary>
        [EnumMember(Value = "info"), Description("绿色")]
        Information,
        /// <summary>
        /// 灰色
        /// </summary>
        [EnumMember(Value = "comment"), Description("灰色")]
        Comment,
        /// <summary>
        /// 橙红色
        /// </summary>
        [EnumMember(Value = "warning"), Description("橙红色")]
        Warning,
    }
}
