using System;
using System.Collections.Generic;

#nullable disable

namespace vetclinic3.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int VetId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public decimal ServicesCost { get; set; }
        public decimal MedsCost { get; set; }
        public string Status { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Vet Vet { get; set; }
    }
}
