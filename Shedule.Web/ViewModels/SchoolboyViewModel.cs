using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Web.ViewModels
{
    /// <summary>
    /// The schoolboy view model.
    /// </summary>
    public class SchoolboyViewModel
    {
        public SchoolboyViewModel()
        {
            this.Tariffs = new List<TariffItemViewModel>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<TariffItemViewModel> Tariffs { get; set; }

        public class TariffItemViewModel
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public int CountOfPairs { get; set; }

            public int Price { get; set; }

            public string TeachingName { get; set; }
        }
    }
}