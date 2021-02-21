using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess
{
    public partial class Location
    {
        public Location()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int LocationId { get; set; }
        public string Nickname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
