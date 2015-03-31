using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Core.Constants
{
    public class Pauses
    {
        public static Dictionary<int, int> PausesDict = new Dictionary<int,int>()
        {
            {1, 10},
            {2, 10},
            {3, 30},
            {4, 10},
            {5, 10},
            {6, 10}
        };
    }
}
