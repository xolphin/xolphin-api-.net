using System;
using System.Globalization;

namespace XolphinApiDotNet.Models.Request
{
    public class FormattedDateTime
    {
        public string Date { get; private set; }
        public string Time { get; private set; }

        public FormattedDateTime(DateTime dateTime)
        {
            Date = dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            Time = dateTime.ToString("HH:mm", CultureInfo.InvariantCulture);
        }
    }
}