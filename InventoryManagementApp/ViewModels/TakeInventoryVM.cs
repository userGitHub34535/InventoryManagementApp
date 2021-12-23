using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementApp.Service;

namespace InventoryManagementApp.ViewModels
{
    public class TakeInventoryVM
    {
        //public TakeInventoryVM(IEnumerable<AssetDTO> assets)
        //{
        //    Asset = assets;
        //}

        //public IEnumerable<AssetDTO> Asset { get; set; }

        public int AssetKey { get; set; }

        public int ProductId { get; set; }

        public string InventoryOwner { get; set; }

        public int LocationId { get; set; }

        public int ClientSiteId { get; set; }
    }
}
