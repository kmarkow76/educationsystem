using System;
using System.Collections.Generic;

#nullable disable

namespace beauty5.Models
{
    public partial class Master
    {
        public Master()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int MasterId { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
