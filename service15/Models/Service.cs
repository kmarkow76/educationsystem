using System;
using System.Collections.Generic;

#nullable disable

namespace service15.Models
{
    public partial class Service
    {
        public Service()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal BasePrice { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
