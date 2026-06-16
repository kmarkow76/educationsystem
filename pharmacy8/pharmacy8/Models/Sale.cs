using System;
using System.Collections.Generic;

#nullable disable

namespace pharmacy8.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime SaleDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Drug Drug { get; set; }
    }
}
