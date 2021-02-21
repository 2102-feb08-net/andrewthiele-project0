using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess
{
    public partial class Invoice
    {
        public Invoice()
        {
            Orders = new HashSet<Order>();
        }

        public int InvoiceId { get; set; }
        public int? CustomerId { get; set; }
        public DateTimeOffset TimeOfOrder { get; set; }
        public int? LocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
