using Pluralize.NET.Core;
using System;
using System.Globalization;

namespace Framework.Utility
{
    public static class StringExtensions
    {
        public static string ToPlural(this string word)
        {
            return new Pluralizer().Pluralize(word);
        }

        public static string Replaceي(this string st)
        {
            return st.Replace('ي', 'ی');
        }
        public static string ToPersianDate(this DateTime datetime)
        {
            var pr = new PersianCalendar();
            return pr.GetYear(datetime) + "/" +
                pr.GetMonth(datetime).ToString("00") + "/" +
                pr.GetDayOfMonth(datetime).ToString("00");
        }
        public static string ToPersianDateTime(this DateTime dateTime)
        {
            if (dateTime == default) return "";
            var pc = new PersianCalendar();
            return $@"{dateTime.Hour:D2}:{dateTime.Minute:D2} - {pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):D2}/{pc.GetDayOfMonth(dateTime):D2}";
        }
        public static string ToPersianDateWithSeconds(this DateTime dateTime)
        {
            if (dateTime == default) return "";
            var pc = new PersianCalendar();
            return $@"{dateTime.Second:D2}:{dateTime.Hour:D2}:{dateTime.Minute:D2} - {pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):D2}/{pc.GetDayOfMonth(dateTime):D2}";
        }
        public static string ToPersianDateFullInfo(this DateTime datetime)
        {
            var DayName = "";
            if (datetime.DayOfWeek == DayOfWeek.Friday)
                DayName = "جمعه";
            if (datetime.DayOfWeek == DayOfWeek.Saturday)
                DayName = "شنبه";
            if (datetime.DayOfWeek == DayOfWeek.Sunday)
                DayName = "یکشنبه";
            if (datetime.DayOfWeek == DayOfWeek.Monday)
                DayName = "دوشنبه";
            if (datetime.DayOfWeek == DayOfWeek.Tuesday)
                DayName = "سه شنبه";
            if (datetime.DayOfWeek == DayOfWeek.Wednesday)
                DayName = "چهار شنبه";
            if (datetime.DayOfWeek == DayOfWeek.Thursday)
                DayName = "پنج شنبه";

            var pr = new PersianCalendar();
            return DayName + "  " +
                pr.GetYear(datetime) + "/" +
                pr.GetMonth(datetime).ToString("00") + "/" +
                pr.GetDayOfMonth(datetime).ToString("00");
        }
        public static DateTime? ToDateTime(this string persianDate)
        {
            var pr = new PersianCalendar();
            if (string.IsNullOrEmpty(persianDate))
                return null;
            try
            {
                var year = Convert.ToInt32(persianDate.Substring(0, 4));
                var month = Convert.ToInt32(persianDate.Substring(5, 2));
                var day = Convert.ToInt32(persianDate.Substring(8, 2));
                return pr.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string ToDetailedPersianTimeString(this long durationInSeconds)
        {
            var duration = TimeSpan.FromSeconds(durationInSeconds);
            if (duration.TotalSeconds < 60)
            {
                return $"{duration.Seconds} ثانیه ";
            }
            if (duration.TotalSeconds > 60)
            {
                return $"{duration.Minutes} دقیقه و {duration.Seconds} ثانیه ";
            }
            return "";
        }
        public static DateTime ToDateTime(this string persianDate, bool isEndOfTheDay = false)
        {
            var pc = new PersianCalendar();

            var persianDateArray = persianDate.Split('/');

            var year = int.Parse(persianDateArray[0]);
            var month = int.Parse(persianDateArray[1]);
            var day = int.Parse(persianDateArray[2]);

            if (isEndOfTheDay)
            {
                return new DateTime(year, month, day, 23, 59, 59, 999, pc);
            }

            return new DateTime(year, month, day, pc);
        }

    }
}