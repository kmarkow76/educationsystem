using System;
using System.Collections.Generic;

#nullable disable

namespace kinoteatr7.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
