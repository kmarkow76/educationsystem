using System;
using System.Collections.Generic;

#nullable disable

namespace dentistry2.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Specialties { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
