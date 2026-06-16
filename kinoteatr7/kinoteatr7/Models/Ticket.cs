using System;
using System.Collections.Generic;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Session Session { get; set; }
    }
}
