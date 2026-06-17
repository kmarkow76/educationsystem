using System;
using System.Collections.Generic;

#nullable disable

namespace vetclinic3.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string PetName { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int AgeYears { get; set; }
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
