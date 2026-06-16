using System;
using System.Collections.Generic;

#nullable disable

namespace restoran9.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Table Table { get; set; }
    }
}
