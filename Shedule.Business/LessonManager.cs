using Shedule.Data;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class LessonManager : ManagerBase
    {
        public LessonManager(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Lesson Add(int teachingId, int periodNumber, int teacherId, int dayNumber, int classroomId)
        {
            Lesson lesson = new Lesson()
            {
                TeachingID = teachingId,
                PeriodNumber = periodNumber,
                TeacherID = teacherId,
                DayNumber = dayNumber,
                ClassroomId = classroomId,
            };

            this.dataContext.Entry(lesson).State = EntityState.Added;
            this.dataContext.SaveChanges();

            return lesson;
        }

        public Lesson[] AllForTeaching(int teachingId)
        {
            return this.dataContext.Lessons.Where(l => l.TeachingID == teachingId)
                .Include(l => l.Teaching).ToArray();
        }

        public Lesson[] AllForDay(int dayNumber)
        {
            return this.dataContext.Lessons.Include(l => l.Classroom).Include(l => l.Teaching).Where(l => l.DayNumber == dayNumber).ToArray();
        }
    }
}
