using Elton.WechatWork.Apps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Elton.WechatWork.Tests
{
    [TestClass]
    public partial class MessageClientTest
    {
        private ApiClient api = null;
        private MessageClient client = null;
        [TestInitialize]
        public void Initialize()
        {
            api = new ApiClient(SecretKeys.CorpId, SecretKeys.AppId, SecretKeys.AppSecret);
            client = new MessageClient(api);
        }

        [TestMethod]
        public async Task TestSendText()
        {
            await client.SendText(
                "你的快递已到，请携带工卡前往邮件中心领取。\n出发前可查看<a href=\"http://work.weixin.qq.com\">邮件中心视频实况</a>，聪明避开排队。",
                "@all");
        }
    }
}