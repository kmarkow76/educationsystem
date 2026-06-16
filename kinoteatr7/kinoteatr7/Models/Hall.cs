using System;
using System.Collections.Generic;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class Hall
    {
        public Hall()
        {
            Sessions = new HashSet<Session>();
        }

        public int HallId { get; set; }
        public string HallName { get; set; }
        public int TotalSeats { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
