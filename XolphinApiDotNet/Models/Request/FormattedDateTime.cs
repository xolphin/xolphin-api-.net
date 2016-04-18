using System;
using System.Globalization;

namespace XolphinApiDotNet.Models.Request
{
    public class FormattedDateTime
    {
        public string date { get; private set; }
        public string time { get; private set; }

        public FormattedDateTime(DateTime dateTime)
        {
            date = dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            time = dateTime.ToString("HH:mm", CultureInfo.InvariantCulture);
        }
    }
}