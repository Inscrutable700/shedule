using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.Helpers
{
    public class DateHelper
    {
        private const int TimeOfLesson = 45;

        private static Dictionary<int, int> Periods = new Dictionary<int, int>()
        {
            {1, 540},
            {2, 600},
            {3, 660},
            {4, 720},
            {5, 780},
            {6, 840},
            {7, 900}
        };

        public static string GetDayNameByNumber(int number)
        {
            string dayName = string.Empty;

            switch (number)
            {
                case 1: dayName = "Понедельник"; break;
                case 2: dayName = "Вторник"; break;
                case 3: dayName = "Среда"; break;
                case 4: dayName = "Четверг"; break;
                case 5: dayName = "Пятница"; break;
                case 6: dayName = "Суббота"; break;
                case 7: dayName = "Воскресенье"; break;
                default: dayName = "ERROR"; break;
            }

            return dayName;
        }

        public static string GetFormattedTimeByPeriodNumber(int periodNumber)
        {
            string result = string.Empty;

            result = FormattedTimeFromMinutes(Periods[periodNumber]);

            return result;
        }

        public static string FormattedTimeFromMinutes(int minutes)
        {
            string result = string.Empty;

            TimeSpan time = TimeSpan.FromMinutes((double)minutes);
            result = string.Format("{0:00}:{1:00}", time.Hours, time.Minutes);
            return result;
        }
    }
}