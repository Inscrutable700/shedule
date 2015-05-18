using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.Models
{
    public class SheduleForTeachingViewModel
    {
        public SheduleForTeachingViewModel()
        {
            this.Days = new Dictionary<int, SheduleDayViewModel>();
            for (int i = 1; i < 6; i++)
            {
                this.Days.Add(i, new SheduleDayViewModel() { DayOfWeek = i });
            }
        }
        public string TeachingName { get; set; }

        public int TeachingId { get; set; }

        public Dictionary<int, SheduleDayViewModel> Days { get; set; }
    }


}