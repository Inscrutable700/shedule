using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class TeacherListViewModel
    {
        public TeacherListViewModel()
        {
            this.Teachers = new List<TeacherItemViewModel>();
        }

        public List<TeacherItemViewModel> Teachers { get; set; }

        public class TeacherItemViewModel
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}