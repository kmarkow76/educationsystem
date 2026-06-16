using System;
using System.Collections.Generic;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class Session
    {
        public Session()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int SessionId { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime SessionDate { get; set; }
        public decimal BasePrice { get; set; }

        public virtual Hall Hall { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
