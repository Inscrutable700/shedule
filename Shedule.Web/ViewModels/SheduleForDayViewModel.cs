using Shedule.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class SheduleForDayViewModel
    {
        public SheduleForDayViewModel()
        {
            this.Lessons = new Dictionary<string, List<LessonItemViewModel>>();
        }

        public int DayOfWeek { get; set; }

        public string DayName
        {
            get
            {
                return DateHelper.GetDayNameByNumber(this.DayOfWeek);
            }
        }

        public Dictionary<string, List<LessonItemViewModel>> Lessons { get; set; }
    }
}