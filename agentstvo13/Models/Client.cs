using System;
using System.Collections.Generic;

#nullable disable

namespace agentstvo13.Models
{
    public partial class Client
    {
        public Client()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool IsRepeat { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
