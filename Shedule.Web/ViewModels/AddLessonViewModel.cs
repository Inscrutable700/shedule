using Shedule.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Web.ViewModels
{
    public class AddLessonViewModel
    {
        public AddLessonViewModel()
        {
            this.Days = new List<SelectListItem>();
            this.Periods = new List<SelectListItem>();
            this.Teachers = new List<SelectListItem>();
            this.Teachings = new List<SelectListItem>();
            this.Classrooms = new List<SelectListItem>();

            for (int i = 1; i < 6; i++)
            {
                this.Days.Add(new SelectListItem() { Value = i.ToString(), Text = DayHelper.GetDayNameByNumber(i)});
            }

            for (int i = 1; i < 8; i++)
            {
                this.Periods.Add(new SelectListItem() { Value = i.ToString(), Text = string.Format("{0}-я пара", i) });
            }
        }

        public List<SelectListItem> Teachers { get; set; }

        public List<SelectListItem> Teachings { get; set; }

        public List<SelectListItem> Days { get; set; }

        public List<SelectListItem> Periods { get; set; }

        public List<SelectListItem> Classrooms { get; set; }
    }
}