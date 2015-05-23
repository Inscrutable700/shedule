using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    public class AddTariffViewModel
    {
        public string Title { get; set; }

        public int CountOfPairs { get; set; }

        public int Price { get; set; }

        public int TeachingId { get; set; }
    }
}