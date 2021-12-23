using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Service
{
    public partial class ClientSiteDTO
    {
        public ClientSiteDTO()
        {
            AssetDTO = new HashSet<AssetDTO>();
        }

        public int ClientSiteKey { get; set; }
        public string ClientSiteName { get; set; }

        public virtual ICollection<AssetDTO> AssetDTO { get; set; }
    }
}
