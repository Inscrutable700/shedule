using System.Collections.Generic;

namespace Shedule.Data.Model
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Schoolboy> Schoolboys { get; set; }

        public int PeriodId { get; set; }

        public Period Period { get; set; }

        public int TeacherID { get; set; }

        public Teacher Teacher { get; set; }
    }
}
