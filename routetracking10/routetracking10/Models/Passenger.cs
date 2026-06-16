using System;
using System.Collections.Generic;

#nullable disable

namespace routetracking10.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool IsPrivileged { get; set; }
        public bool IsRegular { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
