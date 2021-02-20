using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? InvoiceId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
