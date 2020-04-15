using Elton.WechatWork.Models.Message;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Elton.WechatWork.Apps
{
    /// <summary>
    /// 企业微信· API 应用
    /// https://work.weixin.qq.com/api/doc/90000/90135/90236
    /// </summary>
    public partial class MessageClient : IDisposable
    {
        private static readonly ILogger log = Log.ForContext(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly ApiClient api;
        public MessageClient(ApiClient api)
        {
            this.api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public void Dispose()
        {
            //TODO:
        }

        /// <summary>
        /// 文本类型
        /// </summary>
        /// <param name="content">文本内容，最长不超过2048个字节，必须是utf8编码</param>
        /// <param name="mentionedList">userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list</param>
        /// <param name="mentionedMobileList">手机号列表，提醒手机号对应的群成员(@某个成员)，@all表示提醒所有人</param>
        /// <returns></returns>
        public async Task SendText(string content, string touser = null, string toparty = null, string totag = null)
        {
            var message = new TextMessage
            {
                touser = touser,
                toparty = toparty,
                totag = totag,
                agentid = api.AppId,
            };
            message.Text.Content = content;
            await api.SendMessage(message);
        }
    }
}
