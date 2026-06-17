using System;
using System.Collections.Generic;

#nullable disable

namespace vetclinic3.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool IsRegular { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
