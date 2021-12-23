using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementApp.Service;
using InventoryManagementApp.Data.Models;
using InventoryManagementApp.Data;

namespace InventoryManagementApp.ViewComponents
{
    [ViewComponent]
    public class ItemFoundViewComponent : ViewComponent
    {
        private InventoryService _inventoryService;

        public ItemFoundViewComponent(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        //public async Task<IViewComponentResult> InvokeAsync(int id)
        public IViewComponentResult Invoke(int id)
        {
            var items = GetItemsAsync(id);
            return View("_ItemFoundGrid", items);
        }
        private AssetDTO GetItemsAsync(int id)
        {
            return _inventoryService.GetAssetById(id);
        }
    }
}