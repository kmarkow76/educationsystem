using System;
using System.Collections.Generic;

#nullable disable

namespace beauty5.Models
{
    public partial class Client
    {
        public Client()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int IsRegular { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
