using System;
using System.Collections.Generic;

#nullable disable

namespace vetclinic3.Models
{
    public partial class Vet
    {
        public Vet()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
