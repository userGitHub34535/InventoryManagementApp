using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Service
{
    public partial class LocationDTO
    {
        public LocationDTO()
        {
            AssetDTO = new HashSet<AssetDTO>();
        }

        public int LocationKey { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<AssetDTO> AssetDTO { get; set; }
    }
}
