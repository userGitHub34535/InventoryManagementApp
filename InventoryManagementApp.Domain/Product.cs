using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            Asset = new HashSet<Asset>();
        }

        public int ProductId { get; set; }
        public int ProductKey { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
