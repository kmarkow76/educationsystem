using System;
using System.Collections.Generic;

#nullable disable

namespace restoran9.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
