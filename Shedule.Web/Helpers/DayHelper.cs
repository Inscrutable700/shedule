using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.Helpers
{
    public class DayHelper
    {
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
    }
}