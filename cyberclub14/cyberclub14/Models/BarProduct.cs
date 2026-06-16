using System;
using System.Collections.Generic;

#nullable disable

namespace cyberclub14.Models
{
    public partial class BarProduct
    {
        public BarProduct()
        {
            BarSales = new HashSet<BarSale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public virtual ICollection<BarSale> BarSales { get; set; }
    }
}
