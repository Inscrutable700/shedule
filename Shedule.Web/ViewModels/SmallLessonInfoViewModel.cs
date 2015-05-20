using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class SmallLessonInfoViewModel
    {
        public int LessonId { get; set; }

        public string FormattedTimeAndDay { get; set; }
    }
}