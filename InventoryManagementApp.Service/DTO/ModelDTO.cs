using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Service
{
    public partial class ModelDTO
    {
        public ModelDTO()
        {
            AssetDTO = new HashSet<AssetDTO>();
        }

        public int ModelKey { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<AssetDTO> AssetDTO { get; set; }
    }
}
