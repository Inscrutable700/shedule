using System.Collections.Generic;

namespace Shedule.Data.Model
{
    class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LasName { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
