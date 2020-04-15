using System;

namespace Elton.WechatWork
{
    public class ChatbotException : Exception
    {
        public ChatbotException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        public int Code { get; private set; }
    }
}