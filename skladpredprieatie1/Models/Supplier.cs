using System;
using System.Collections.Generic;

#nullable disable

namespace skladpredprieatie1.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPhone { get; set; }
        public bool IsPermanent { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
