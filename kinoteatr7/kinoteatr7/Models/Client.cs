using System;
using System.Collections.Generic;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class Client
    {
        public Client()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int? IsRegular { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
