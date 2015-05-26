using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shedule.Data.Model
{
    public class SchoolboyToTariff
    {
        [Key, Column(Order = 1)]
        public int SchoolboyId { get; set; }

        public Schoolboy Schoolboy { get; set; }

        public int TariffId { get; set; }

        public Tariff Tariff { get; set; }

        [Key, Column(Order = 2)]
        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }
}
