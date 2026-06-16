using System;
using System.Collections.Generic;

#nullable disable

namespace pharmacy8.Models
{
    public partial class Drug
    {
        public Drug()
        {
            Receipts = new HashSet<Receipt>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool? AvailabilityStatus { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
