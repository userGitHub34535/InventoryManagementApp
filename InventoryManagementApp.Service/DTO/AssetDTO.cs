using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InventoryManagementApp.Data;
using InventoryManagementApp.Data.Models;

namespace InventoryManagementApp.Service
{
    public partial class AssetDTO
    {
        [Display(Name = "Asset Tag")]
        public int AssetKey { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase Date")] 
        public DateTime? PurchaseDate { get; set; }
        [Display(Name = "Inventory Owner")]
        public string InventoryOwner { get; set; }
        [Display(Name = "Inventoried By")] 
        public string InventoriedBy { get; set; }

        [Display(Name = "Inventory Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InventoryDate { get; set; }
        [Display(Name = "Is Disposed")]
        public bool? IsDisposed { get; set; }

        public int ProductId { get; set; }
        public int ManuafcturerId { get; set; }
        public int ModelId { get; set; }
        public int LocationId { get; set; }
        public int ClientSiteId { get; set; }

        [Display(Name = "Client Site")]
        public virtual ClientSite ClientSite { get; set; }
        public virtual Location Location { get; set; }
        public virtual Manufacturer Manuafcturer { get; set; }
        public virtual Model Model { get; set; }
        public virtual Product Product { get; set; }
    }
}
