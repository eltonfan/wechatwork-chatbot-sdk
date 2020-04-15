using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Elton.WechatWork.Tests
{
    [TestClass]
    public partial class ChatbotClientTest
    {
        private ChatbotClient client = null;
        [TestInitialize]
        public void Initialize()
        {
            client = new ChatbotClient(SecretKeys.CHATBOT_WEBHOOK_ACCESS_TOKEN);
        }

        [TestMethod]
        public async Task TestSendText()
        {
            await client.SendText("广州今日天气：29度，大部分多云，降雨概率：60%",
                new[] { "wangqing", "@all" },
                new[] { "13800001111", "@all" });
        }

        [TestMethod]
        public async Task TestSendMarkdown()
        {
            await client.SendMarkdown("实时新增用户反馈<font color=\"warning\">132例</font>，请相关同事注意。\n"
                + ">类型:<font color=\"comment\">用户反馈</font>\n"
                + ">普通用户反馈:<font color=\"comment\">117例</font>\n"
                + ">VIP用户反馈:<font color=\"comment\">15例</font>\n");
        }

        [TestMethod]
        public async Task TestSendImage()
        {
            var imageData = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"examples\eltonfan.png"));
            await client.SendImage(imageData);
        }

        [TestMethod]
        public async Task TestSendNews()
        {
            await client.SendNews(
                title: "中秋节礼品领取",
                description: "今年中秋节公司有豪礼相送",
                url: "www.qq.com",
                pictureUrl: "http://res.mail.qq.com/node/ww/wwopenmng/images/independent/doc/test_pic_msg1.png");
        }
    }
}