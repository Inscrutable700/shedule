using Shedule.Data;
using Shedule.Data.Model;
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
            return this.dataContext.Teachers.Find(teacherId);
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
    }
}
