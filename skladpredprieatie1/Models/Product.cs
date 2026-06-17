using System;
using System.Collections.Generic;

#nullable disable

namespace skladpredprieatie1.Models
{
    public partial class Product
    {
        public Product()
        {
            WarehouseOperations = new HashSet<WarehouseOperation>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string UnitOfMeasure { get; set; }
        public int QuantityInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<WarehouseOperation> WarehouseOperations { get; set; }
    }
}
