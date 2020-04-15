using Elton.WechatWork.Apps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Elton.WechatWork.Tests
{
    [TestClass]
    public partial class ApiClientTest
    {
        private ApiClient api = null;
        [TestInitialize]
        public void Initialize()
        {
            api = new ApiClient(SecretKeys.CorpId, SecretKeys.AppId, SecretKeys.AppSecret);
        }

        [TestMethod]
        public async Task TestGetAccessToken()
        {
            var token = await api.GetAccessToken();
            Assert.IsNotNull(token?.AccessToken);
        }
    }
}