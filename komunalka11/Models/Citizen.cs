using System;
using System.Collections.Generic;

#nullable disable

namespace komunalka11.Models
{
    public partial class Citizen
    {
        public Citizen()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public bool HasPrivilege { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
