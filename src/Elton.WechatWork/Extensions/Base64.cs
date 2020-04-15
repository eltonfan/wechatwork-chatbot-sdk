using System;
using System.Text;

namespace Elton.WechatWork
{
	public static class Base64
	{
		public static string ToBase64(this byte[] bytes)
		{
			return Convert.ToBase64String(bytes);
        }

        public static byte[] AsBase64Bytes(this string base64String)
		{
			return Convert.FromBase64String(base64String);
		}

		/// <summary>
		/// UTF8 Encoding.
		/// </summary>
		/// <param name="plainText"></param>
		/// <returns></returns>
		public static string ToBase64(this string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		/// <summary>
		/// UTF8 Encoding.
		/// </summary>
		/// <param name="base64String"></param>
		/// <returns></returns>
		public static string AsBase64String(this string base64String)
		{
			var bytes = Convert.FromBase64String(base64String);
			return Encoding.UTF8.GetString(bytes);
		}
    }
}
