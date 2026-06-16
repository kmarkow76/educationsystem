using System;
using System.Collections.Generic;

#nullable disable

namespace restoran9.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderitems = new HashSet<Orderitem>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? DiscountPercent { get; set; }
        public decimal? FinalAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<Orderitem> Orderitems { get; set; }
    }
}
