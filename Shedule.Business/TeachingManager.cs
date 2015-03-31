using Shedule.Data;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    class TeachingManager : ManagerBase
    {
        public TeachingManager(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Teaching Get(int teachingId)
        {
            return this.dataContext.Teachings.SingleOrDefault(t => t.Id == teachingId);
        }
    }
}
