using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Service
{
    public partial class ProductDTO
    {
        public ProductDTO()
        {
            AssetDTO = new HashSet<AssetDTO>();
        }

        public int ProductKey { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<AssetDTO> AssetDTO { get; set; }
    }
}
