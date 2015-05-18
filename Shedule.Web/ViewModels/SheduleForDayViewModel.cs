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
            this.Lessons = new Dictionary<string, List<LessonViewModel>>();
        }

        public int DayOfWeek { get; set; }

        public string DayName
        {
            get
            {
                return DayHelper.GetDayNameByNumber(this.DayOfWeek);
            }
        }

        public Dictionary<string, List<LessonViewModel>> Lessons { get; set; }

        public class LessonViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}