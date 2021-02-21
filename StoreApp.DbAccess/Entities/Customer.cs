using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
