using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
