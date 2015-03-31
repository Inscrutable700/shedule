using Shedule.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Business
{
    public class ManagerBase
    {
        protected DataContext dataContext;


        public ManagerBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
