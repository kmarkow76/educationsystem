using System;
using System.Collections.Generic;

#nullable disable

namespace skladpredprieatie1.Models
{
    public partial class WarehouseOperation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public string OperationType { get; set; }
        public int Quantity { get; set; }
        public DateTime OperationDate { get; set; }
        public string RecipientName { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
    }
}
