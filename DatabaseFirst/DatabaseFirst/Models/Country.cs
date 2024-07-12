using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public ushort CountryId { get; set; }
        public string Country1 { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
