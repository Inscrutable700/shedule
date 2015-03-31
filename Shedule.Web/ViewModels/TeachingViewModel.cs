using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class TeachingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public List<LessonViewModel> Lessons { get; set; }
    }
}