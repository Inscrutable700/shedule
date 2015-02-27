using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Core.Constants
{
    public class Pauses
    {
        private static Dictionary<int, int> pausesInMinute = new Dictionary<int,int>()
        {
            {1, 10},
            {2, 10},
            {3, 30},
            {4, 10},
            {5, 10},
            {6, 10}
        };

        public static Dictionary<int, int> Pauses
        {
            get
            {
                return pausesInMinute;
            }
        }
    }
}
