using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class LessonsAndTarifsForTeachingViewModel
    {
        public LessonsAndTarifsForTeachingViewModel()
        {
            this.Lessons = new List<LessonItemViewModel>();
            this.Tariffs = new List<TariffItemViewModel>();
        }

        public List<LessonItemViewModel> Lessons { get; set; }

        public List<TariffItemViewModel> Tariffs { get; set; }

        public class TariffItemViewModel
        {
            public int TariffId { get; set; }

            public string FormattedInfo { get; set; }
        }

        public class LessonItemViewModel
        {
            public int LessonId { get; set; }

            public string FormattedTimeAndDay { get; set; }
        }
    }
}