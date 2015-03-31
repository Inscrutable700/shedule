using Shedule.Data;
using Shedule.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Shedule.Business
{
    public class SchoolboyManager : ManagerBase 
    {
        public SchoolboyManager(DataContext context)
            : base(context)
        {
        }

        public Schoolboy Get(int schoolboyID)
        {
            Schoolboy schoolboy = this.dataContext.Schoolboys.Find(schoolboyID);

            return schoolboy;
        }

        public Schoolboy[] List(int LessonID)
        {
            var lesson = this.dataContext.Lessons.Find(LessonID);
            return lesson.Schoolboys.ToArray();
        }

        public Schoolboy Add(Schoolboy schoolboy)
        {
            return this.dataContext.Schoolboys.Add(schoolboy);
        }

        public Schoolboy Add(Schoolboy schoolboy, List<Lesson> lessons)
        {
            schoolboy = this.dataContext.Schoolboys.Add(schoolboy);
            schoolboy.Lessons.AddRange(lessons);
            this.dataContext.SaveChanges();

            return schoolboy;
        }
    }
}
