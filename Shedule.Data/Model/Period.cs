using Shedule.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Data.Model
{
    class Period
    {
        public int Id { get; set; }

        public long BeginTimeOfDay { get; set; }

        private long endTimeOfDay = -1;

        public long EndTimeOfDay
        {
            get 
            {
                if (this.endTimeOfDay == -1)
                {
                    this.endTimeOfDay = this.BeginTimeOfDay;

                    if (Pauses.Pauses.ContainsKey(this.Id))
                    {
                        this.endTimeOfDay += Pauses.Pauses[this.Id];
                    }
                }

                return this.endTimeOfDay;
            }
        }
    }
}
