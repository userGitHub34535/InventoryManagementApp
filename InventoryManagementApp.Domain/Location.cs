using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            Asset = new HashSet<Asset>();
        }

        public int LocationId { get; set; }
        public int LocationKey { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
