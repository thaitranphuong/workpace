using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rentals = new HashSet<Rental>();
        }

        public uint InventoryId { get; set; }
        public ushort FilmId { get; set; }
        public byte StoreId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Film Film { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
