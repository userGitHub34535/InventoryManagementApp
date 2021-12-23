using System;
using System.Collections.Generic;

namespace InventoryManagementApp.Data.Models
{
    public partial class ClientSite
    {
        public ClientSite()
        {
            Asset = new HashSet<Asset>();
        }

        public int ClientSiteId { get; set; }
        public int ClientSiteKey { get; set; }
        public string ClientSiteName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
