using System;
using System.Collections.Generic;

#nullable disable

namespace pharmacy8.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
