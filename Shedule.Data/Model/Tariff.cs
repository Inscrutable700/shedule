using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Data.Model
{
    public class Tariff
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int TeachingId { get; set; }

        public Teaching Teaching { get; set; }

        public int CountOfPairs { get; set; }

        public int Price { get; set; }
    }
}
