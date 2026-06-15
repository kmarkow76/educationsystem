using System;
using System.Collections.Generic;

#nullable disable

namespace dentistry2.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Gender { get; set; }
        public string Policy { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
