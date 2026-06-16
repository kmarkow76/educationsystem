using System;
using System.Collections.Generic;

#nullable disable

namespace routetracking10.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int PassengerId { get; set; }
        public string TicketType { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Passenger Passenger { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
