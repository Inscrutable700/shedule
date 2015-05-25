using Shedule.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.Models
{
    public class SheduleDayViewModel
    {
        public SheduleDayViewModel()
        {
            this.Lessons = new List<LessonViewModel>();
        }

        public int DayOfWeek { get; set; }

        public string Name
        {
            get
            {
                return DateHelper.GetDayNameByNumber(this.DayOfWeek);
            }
        }

        public List<LessonViewModel> Lessons { get; set; }

        public class LessonViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string ClassroomName { get; set; }

            public int PeriodNumber { get; set; }

            public string TeacherName { get; set; }
        }
    }
}