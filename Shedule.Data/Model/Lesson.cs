using System;
using System.Collections.Generic;

namespace Shedule.Data.Model
{
    public class Lesson
    {
        public int Id { get; set; }

        public List<Schoolboy> Schoolboys { get; set; }

        public int TeachingID { get; set; }

        public Teaching Teaching { get; set; }

        public DateTime Begin { get; set; }

        public int PeriodNumber { get; set; }

        public int TeacherID { get; set; }

        public Teacher Teacher { get; set; }

        public int Count { get; set; }
    }
}
