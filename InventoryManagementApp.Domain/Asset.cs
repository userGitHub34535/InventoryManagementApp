using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InventoryManagementApp.Data.Models
{
    public partial class Asset
    {
        public int AssetId { get; set; }
        
        [DisplayName("Asset Tag")] //AssetKey is the one which users can enter & modify
        public int AssetKey { get; set; }
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string InventoryOwner { get; set; }
        public string InventoriedBy { get; set; }
        public DateTime? InventoryDate { get; set; }
        public bool? IsDisposed { get; set; }
        public int ProductId { get; set; }
        public int ManuafcturerId { get; set; }
        public int ModelId { get; set; }
        public int LocationId { get; set; }
        public int ClientSiteId { get; set; }

        public virtual ClientSite ClientSite { get; set; }
        public virtual Location Location { get; set; }
        public virtual Manufacturer Manuafcturer { get; set; }
        public virtual Model Model { get; set; }
        public virtual Product Product { get; set; }
    }
}
