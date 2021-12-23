using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Data.Models
{
    public partial class Model
    {
        public Model()
        {
            Asset = new HashSet<Asset>();
        }

        public int ModelId { get; set; }
        public int ModelKey { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
