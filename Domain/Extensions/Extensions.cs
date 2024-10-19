using System.ComponentModel;

namespace Raffle.Domain.Extensions
{
    public static class Extensions
    {
        public static DateTime GetColombiaDateNow(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneSO()));
        }

        private static string GetTimeZoneSO()
        {
            return Environment.OSVersion.Platform.Equals(PlatformID.Win32NT) ? "SA Pacific Standard Time" : "America/Bogota";
        }

        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value
                .GetType()
                .GetField(value.ToString())!;

            var attributes = (DescriptionAttribute[])fieldInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes != null && attributes.Length > 0
                ? attributes[0].Description
                : value.ToString();
        }
    }
}
