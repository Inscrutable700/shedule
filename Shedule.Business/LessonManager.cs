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

        public Lesson Add(int teachingId, int periodNumber, DateTime beginDate, int count, int teacherId)
        {
            Lesson lesson = new Lesson()
            {
                TeachingID = teachingId,
                PeriodNumber = periodNumber,
                Begin = beginDate,
                Count = count,
                TeacherID = teacherId
            };

            this.dataContext.Entry(lesson).State = EntityState.Added;
            this.dataContext.SaveChanges();

            return lesson;
        }
    }
}
