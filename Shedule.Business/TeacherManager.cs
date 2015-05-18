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

        public Teacher[] All()
        {
            return this.dataContext.Teachers.ToArray();
        }
    }
}
