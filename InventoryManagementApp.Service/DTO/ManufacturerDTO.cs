using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Service
{
    public partial class ManufacturerDTO
    {
        public ManufacturerDTO()
        {
            AssetDTO = new HashSet<AssetDTO>();
        }

        public int ManufacturerKey { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<AssetDTO> AssetDTO { get; set; }
    }
}
