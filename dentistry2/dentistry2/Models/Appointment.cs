using System;
using System.Collections.Generic;

#nullable disable

namespace dentistry2.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
