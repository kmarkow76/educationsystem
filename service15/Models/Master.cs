using System;
using System.Collections.Generic;

#nullable disable

namespace service15.Models
{
    public partial class Master
    {
        public Master()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
