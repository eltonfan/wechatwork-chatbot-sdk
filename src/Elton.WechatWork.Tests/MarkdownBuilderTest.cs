using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Elton.WechatWork.Tests
{
    [TestClass]
    public partial class MarkdownBuilderTest
    {
        private ChatbotClient client = null;
        [TestInitialize]
        public void Initialize()
        {
            client = new ChatbotClient(SecretKeys.CHATBOT_WEBHOOK_ACCESS_TOKEN);
        }

        [TestMethod]
        public async Task TestSendMarkdown()
        {
            //目前支持的markdown语法是如下的子集
            var markdownText = new MarkdownBuilder()

                //1. 标题 （支持1至6级标题，注意#与文字中间要有空格）
                .AppendHeaderText(1, "标题一")
                .AppendHeaderText(2, "标题二")
                .AppendHeaderText(3, "标题三")
                .AppendHeaderText(4, "标题四")
                .AppendHeaderText(5, "标题五")
                .AppendHeaderText(6, "标题六")

                //2. 加粗
                .AppendBoldText("bold")
                .AppendLine()

                //3. 链接
                .AppendLinkText("这是一个链接", "http://work.weixin.qq.com/api/doc")
                .AppendLine()

                //4. 行内代码段（暂不支持跨行）
                .AppendCode("code")
                .AppendLine()

                //5. 引用
                .AppendReferenceText("引用文字")
                .AppendLine()

                //6. 字体颜色(只支持3种内置颜色)
                .AppendColorText(TextColor.Information, "绿色")
                .AppendColorText(TextColor.Comment, "灰色")
                .AppendColorText(TextColor.Warning, "橙红色")
                .AppendLine()

                .Append("normal text")
                .AppendLine()

                .Build();

            await client.SendMarkdown(markdownText);
        }
    }
}