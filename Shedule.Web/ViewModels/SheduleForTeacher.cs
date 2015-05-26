using Shedule.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Web.ViewModels
{
    public class SheduleForTeacher
    {
        public SheduleForTeacher()
        {
            this.Lessons = new Dictionary<string, List<LessonItemViewModel>>();
            this.Teachings = new List<SelectListItem>();
            this.Days = new Dictionary<int, SheduleDayViewModel>();
            for (int i = 1; i < 6; i++)
            {
                this.Days.Add(i, new SheduleDayViewModel() { DayOfWeek = i });
            }
        }

        public int TeacherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Dictionary<string, List<LessonItemViewModel>> Lessons { get; set; }

        public List<SelectListItem> Teachings { get; set; }

        public Dictionary<int, SheduleDayViewModel> Days { get; set; }
    }
}