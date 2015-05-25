using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Data.Model
{
    public class Schoolboy
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public List<SchoolboyToTariff> SchoolboyToTariffs { get; set; }
    }
}
