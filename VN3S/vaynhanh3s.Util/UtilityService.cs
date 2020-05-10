using System;

namespace vaynhanh3s.Util
{
    public class UtilityService
    {
        public static DateTime ConvertDateTimeOffsetToDateTime(DateTimeOffset dateTime, string timezoneId)
        {
            if (dateTime.Offset.Equals(TimeSpan.Zero))
                return dateTime.UtcDateTime;

            return dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime)) ? DateTime.SpecifyKind(dateTime.DateTime, DateTimeKind.Local) : dateTime.DateTime;
        }

        public DateTime TimestampToDateTime(long timestamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp);
            return dtDateTime;
        }

        public string FormatUserName(Guid orgId, string username)
        {
            return string.Empty;
        }

    }
}
