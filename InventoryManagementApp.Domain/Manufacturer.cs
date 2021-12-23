using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Data.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Asset = new HashSet<Asset>();
        }

        public int ManufacturerId { get; set; }
        public int ManufacturerKey { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
