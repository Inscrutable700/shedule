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

        private SchoolboyManager schoolboyManager { get; set; }

        public ManagerBase()
        {
            this.dataContext = new DataContext();
        }

        public SchoolboyManager SchoolboyManager
        {
            get
            {
                if (this.schoolboyManager == null)
                {
                    this.schoolboyManager = new SchoolboyManager(this.dataContext);
                }

                return this.schoolboyManager;
            }
        }
    }
}
