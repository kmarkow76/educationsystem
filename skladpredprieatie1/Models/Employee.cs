using System;
using System.Collections.Generic;

#nullable disable

namespace skladpredprieatie1.Models
{
    public partial class Employee
    {
        public Employee()
        {
            WarehouseOperations = new HashSet<WarehouseOperation>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public virtual ICollection<WarehouseOperation> WarehouseOperations { get; set; }
    }
}
