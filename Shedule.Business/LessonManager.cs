using Shedule.Data;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    class LessonManager : ManagerBase
    {
        public LessonManager(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Lesson Add(string name, int PeriodID, int[] daysOfWeek)
        {
            Lesson lesson = new Lesson()
            {
                Name = name,
                PeriodId = PeriodID
            };

            return lesson;
        }
    }
}
