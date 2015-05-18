using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class TeachingDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ClassroomId { get; set; }

        public string ClassroomName { get; set; }

        public int PeriodNumber { get; set; }

        public List<LessonViewModel> Lessons { get; set; }
    }
}