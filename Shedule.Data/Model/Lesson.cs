using System;
using System.Collections.Generic;

namespace Shedule.Data.Model
{
    public class Lesson
    {
        public int Id { get; set; }

        public int TeachingID { get; set; }

        public Teaching Teaching { get; set; }

        public int PeriodNumber { get; set; }

        public int DayNumber { get; set; }

        public int TeacherID { get; set; }

        public Teacher Teacher { get; set; }

        public Classroom Classroom { get; set; }

        public int ClassroomId { get; set; }
    }
}
