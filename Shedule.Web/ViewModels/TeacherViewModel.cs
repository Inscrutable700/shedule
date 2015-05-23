using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LasName { get; set; }

        public string MiddleName { get; set; }

        public string Description { get; set; }

        public string Degree { get; set; }

        public DateTime Birthday { get; set; }
    }
}