using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class TeachingViewModel
    {
        public TeachingViewModel()
        {
            this.Lessons = new List<LessonViewModel>();
            this.Tariffs = new List<TariffItemViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public List<LessonViewModel> Lessons { get; set; }

        public List<TariffItemViewModel> Tariffs { get; set; }

        public class TariffItemViewModel 
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public int CountOfPairs { get; set; }

            public int Price { get; set; }
        }
    }
}