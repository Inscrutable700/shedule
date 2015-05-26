using Shedule.Data;
using Shedule.Data.Model;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class TeacherManager : ManagerBase
    {
        public TeacherManager(DataContext dataContext)
            :base(dataContext)
        {
        }

        public Teacher Get(int teacherId) 
        {
            return this.dataContext.Teachers
                .Include(t => t.Lessons.Select(l => l.Teacher))
                .Include(t => t.Lessons.Select(l => l.Teaching))
                .Include(t => t.Lessons.Select(l => l.Classroom))
                .Single(t => t.Id == teacherId);
        }

        public Teacher[] All()
        {
            return this.dataContext.Teachers.ToArray();
        }

        public Teacher Add(
            string firstName,
            string lastName,
            string middleName,
            string description,
            string deegre,
            DateTime birthday)
        {
            Teacher newTeacher = this.dataContext.Teachers.Add(new Teacher()
            {
                FirstName = firstName,
                LasName = lastName,
                Degree = deegre,
                Description = description,
                MiddleName = middleName,
                Birthday = birthday,
            });

            this.dataContext.SaveChanges();

            return newTeacher;
        }

        public void AddLesson(int teacherId, int lessonId)
        {
            Teacher teacher = this.dataContext.Teachers.Find(teacherId);
            Lesson lesson = this.dataContext.Lessons.Find(lessonId);
            teacher.Lessons.Add(lesson);
            this.dataContext.SaveChanges();
        }
    }
}
