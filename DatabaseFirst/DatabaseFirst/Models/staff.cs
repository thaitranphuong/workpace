﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class staff
    {
        public staff()
        {
            Payments = new HashSet<Payment>();
            Rentals = new HashSet<Rental>();
        }

        public byte StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort AddressId { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public byte StoreId { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Store StoreNavigation { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
