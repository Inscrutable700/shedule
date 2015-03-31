using Shedule.Data;
using Shedule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class TeachingManager : ManagerBase
    {
        public TeachingManager(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Teaching Get(int teachingId)
        {
            return this.dataContext.Teachings.SingleOrDefault(t => t.Id == teachingId);
        }

        public List<Teaching> All()
        {
            return this.dataContext.Teachings.ToList();
        }
    }
}
