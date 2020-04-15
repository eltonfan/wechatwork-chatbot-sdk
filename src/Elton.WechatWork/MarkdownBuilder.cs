using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Elton.WechatWork
{
    public class MarkdownBuilder
    {
        private readonly List<string> listItems = new List<string>();

        public MarkdownBuilder Append(string text)
        {
            listItems.Add(text);
            return this;
        }

        public MarkdownBuilder AppendLine()
        {
            listItems.Add("\n");
            return this;
        }

        public MarkdownBuilder AppendLine(string text)
        {
            listItems.Add(text + "\n");
            return this;
        }

        /// <summary>
        /// 标题 （支持1至6级标题，注意#与文字中间要有空格）
        /// </summary>
        /// <param name="headerType"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public MarkdownBuilder AppendHeaderText(int headerType, string text)
        {
            if (headerType < 1 || headerType > 6)
            {
                throw new ArgumentException("headerType should be in [1, 6]");
            }

            var numbers = new StringBuilder();
            for (int i = 0; i < headerType; i++)
            {
                numbers.Append("#");
            }
            return AppendLine(numbers + " " + text);
        }

        /// <summary>
        /// 加粗
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public MarkdownBuilder AppendBoldText(string text)
        {
            return Append("**" + text + "**");
        }

        /// <summary>
        /// 链接
        /// </summary>
        /// <param name="text"></param>
        /// <param name="href"></param>
        /// <returns></returns>
        public MarkdownBuilder AppendLinkText(string text, string href)
        {
            return Append("[" + text + "](" + href + ")");
        }

        /// <summary>
        /// 行内代码段（暂不支持跨行）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public MarkdownBuilder AppendCode(string text)
        {
            return Append("`" + text + "`");
        }

        /// <summary>
        /// 引用
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public MarkdownBuilder AppendReferenceText(string text)
        {
            return Append("> " + text);
        }

        /// <summary>
        /// 字体颜色(只支持3种内置颜色)
        /// </summary>
        /// <param name="color"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public MarkdownBuilder AppendColorText(TextColor color, string text)
        {
            return Append($"<font color=\"{color.ToEnumMemberValue()}\">{text}</font>");
        }

        public string Build()
        {
            var markdownText = new StringBuilder();
            foreach (var item in listItems)
            {
                markdownText.Append(item);
            }

            return markdownText.ToString();
        }
    }
}
