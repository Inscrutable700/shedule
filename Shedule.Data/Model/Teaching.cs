using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Data.Model
{
    public class Teaching
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public List<Tariff> Tariffs { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
