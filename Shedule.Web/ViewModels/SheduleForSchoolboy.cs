using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Web.ViewModels
{
    public class SheduleForSchoolboy
    {
        public SheduleForSchoolboy()
        {
            this.Lessons = new Dictionary<string, List<LessonItemViewModel>>();
            this.Teachings = new List<SelectListItem>();
        }

        public int SchoolboyId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Dictionary<string, List<LessonItemViewModel>> Lessons { get; set; }

        public List<SelectListItem> Teachings { get; set; }
    }
}