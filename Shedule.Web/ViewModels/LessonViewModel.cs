using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class LessonViewModel
    {
        public int TeachingId { get; set; }

        public int TeacherId { get; set; }

        public string Name { get; set; }

        public int DayOfWeekNumber { get; set; }

        public int PeriodNumber { get; set; }

        public int ClassroomId { get; set; }
    }
}