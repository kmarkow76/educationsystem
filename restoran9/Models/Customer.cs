using System;
using System.Collections.Generic;

#nullable disable

namespace restoran9.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? IsPermanent { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
