using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elton.WechatWork.JsonConverters
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            base.DateTimeFormat = format;
        }
    }

    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = CustomDateTimeConverter.FormatString;
        }

        public const string FormatString = "yyyy-MM-ddTHH:mm:ss.fff";
    }
}
