using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementApp.Data;
using InventoryManagementApp.Data.Models;
using InventoryManagementApp.Service;
using InventoryManagementApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Controllers
{
    public class TakeInventoryController : Controller
    {
        private InventoryService _inventoryService;

        public TakeInventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Take Inventory";

            #region Location Drop Down
            List<SelectListItem> locationDropDown = new List<SelectListItem>();
            List<Location> locations = _inventoryService.GetAllLocations();

            foreach (Location location in locations)
            {
                locationDropDown.Add(new SelectListItem() { Text = location.LocationName, Value = location.LocationKey.ToString() });
            }

            ViewBag.GetLocationDropDown = locationDropDown;
            #endregion

            #region Client Site Drop Down
            List<SelectListItem> clientSiteDropDown = new List<SelectListItem>();
            List<ClientSiteDTO> clientSites = _inventoryService.GetAllClientSites();

            foreach (ClientSiteDTO clientSite in clientSites)
            {
                clientSiteDropDown.Add(new SelectListItem() { Text = clientSite.ClientSiteName, Value = clientSite.ClientSiteKey.ToString() });
            }

            ViewBag.GetClientSiteDropDown = clientSiteDropDown;
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult Index(TakeInventoryVM selectedAsset)
        {
            ViewBag.Title = "Take Inventory";

            int assetKey = selectedAsset.AssetKey;
            AssetDTO fromDBAssetById = _inventoryService.GetAssetById(assetKey);

            //todo-fix the repeated DropDown code
            #region Location Drop Down
            List<SelectListItem> locationDropDown = new List<SelectListItem>();
            List<Location> locations = _inventoryService.GetAllLocations();

            foreach (Location location in locations)
            {
                locationDropDown.Add(new SelectListItem() { Text = location.LocationName, Value = location.LocationKey.ToString() });
            }

            ViewBag.GetLocationDropDown = locationDropDown;
            #endregion

            #region Client Site Drop Down
            List<SelectListItem> clientSiteDropDown = new List<SelectListItem>();
            List<ClientSiteDTO> clientSites = _inventoryService.GetAllClientSites();

            foreach (ClientSiteDTO clientSite in clientSites)
            {
                clientSiteDropDown.Add(new SelectListItem() { Text = clientSite.ClientSiteName, Value = clientSite.ClientSiteKey.ToString() });
            }

            ViewBag.GetClientSiteDropDown = clientSiteDropDown;
            #endregion

            if (fromDBAssetById == null)
            //can't find the assetKey, so return the _NotFound partial view
            {
                TakeInventoryVM userInput = new TakeInventoryVM();
                userInput.AssetKey = assetKey;
                return View(userInput);
            }
            //todo-todo-this needs to be put in a separate partial view I beleive. I.e. when the asset key is found, it needs to bring the table back as a partial, because it's a diffent model (takeInventoryVM and AssetDTO are differnt models)
            selectedAsset.ProductId = fromDBAssetById.ProductId;
            return View(selectedAsset);
        }

        public IActionResult ItemFoundGrid(int id)
        {
            AssetDTO fromDBAssetById = _inventoryService.GetAssetById(id);

            return View("_ItemFoundGrid", fromDBAssetById);
        }

        [HttpPost]
        public IActionResult CreateNewAsset(AssetDTO newAsset)
        {
            _inventoryService.SaveNewAsset(newAsset);

            //todo
            //try
            //{
            //    //
            //}catch (Exception e)
            //{
            //    throw new Exception(404, "CreateNewAssetMethodUseCaught");
            //}

            //todo-fix the repeated DropDown code
            #region Location Drop Down
            List<SelectListItem> locationDropDown = new List<SelectListItem>();
            List<Location> locations = _inventoryService.GetAllLocations();

            foreach (Location location in locations)
            {
                locationDropDown.Add(new SelectListItem() { Text = location.LocationName, Value = location.LocationKey.ToString() });
            }

            ViewBag.GetLocationDropDown = locationDropDown;
            #endregion

            #region Client Site Drop Down
            List<SelectListItem> clientSiteDropDown = new List<SelectListItem>();
            List<ClientSiteDTO> clientSites = _inventoryService.GetAllClientSites();

            foreach (ClientSiteDTO clientSite in clientSites)
            {
                clientSiteDropDown.Add(new SelectListItem() { Text = clientSite.ClientSiteName, Value = clientSite.ClientSiteKey.ToString() });
            }

            ViewBag.GetClientSiteDropDown = clientSiteDropDown;
            #endregion

            return View("Index");
        }

        [HttpGet]
        public IActionResult AddModifyItemModal(int id, TakeInventoryVM userDetails)
        {
            //when id  = 0, we are adding a new item
            //when id != 0, we are modifying an item
            AssetDTO asset = _inventoryService.GetAssetById(id);

            #region Product drop down
            //build Product drop down
            List<ProductDTO> products = _inventoryService.GetAllProductsDTO();

            List<SelectListItem> productDropdown = new List<SelectListItem>();
            foreach (ProductDTO p in products)
            {
                productDropdown.Add(new SelectListItem() { Text = p.ProductName, Value = p.ProductKey.ToString() });
            }

            ViewBag.GetProductDropDown = productDropdown;
            #endregion

            #region Manufacturer drop down
            //build Manufacturer drop down
            List<ManufacturerDTO> manufacturers = _inventoryService.GetAllManufacturersDTO();

            List<SelectListItem> manufacturerDropdown = new List<SelectListItem>();
            foreach (ManufacturerDTO m in manufacturers)
            {
                manufacturerDropdown.Add(new SelectListItem() { Text = m.ManufacturerName, Value = m.ManufacturerKey.ToString() });
            }

            ViewBag.GetManufacturerDropDown = manufacturerDropdown;
            #endregion

            #region Model drop down
            //build Model drop down
            List<ModelDTO> models = _inventoryService.GetAllModelsDTO();

            List<SelectListItem> modelDropdown = new List<SelectListItem>();
            foreach (ModelDTO m in models)
            {
                modelDropdown.Add(new SelectListItem() { Text = m.ModelName, Value = m.ModelKey.ToString() });
            }

            ViewBag.GetModelDropDown = modelDropdown;
            #endregion

            #region ClientSite Drop Down 
            //build client site DropDownList
            List<ClientSiteDTO> clientSites = _inventoryService.GetAllClientSites()
                                                               .Select(x => new ClientSiteDTO
                                                               {
                                                                   ClientSiteKey = x.ClientSiteKey,
                                                                   ClientSiteName = x.ClientSiteName
                                                               })
                                                               .ToList();

            List<SelectListItem> clientSiteDropdown = new List<SelectListItem>();
            foreach (ClientSiteDTO site in clientSites)
            {
                clientSiteDropdown.Add(new SelectListItem() { Text = site.ClientSiteName, Value = site.ClientSiteKey.ToString() });
            }

            ViewBag.GetClientSiteDropDown = clientSiteDropdown;
            #endregion

            //todo-fix the repeated DropDown code
            #region Location Drop Down
            List<SelectListItem> locationDropDown = new List<SelectListItem>();
            List<Location> locations = _inventoryService.GetAllLocations();

            foreach (Location location in locations)
            {
                locationDropDown.Add(new SelectListItem() { Text = location.LocationName, Value = location.LocationKey.ToString() });
            }

            ViewBag.GetLocationDropDown = locationDropDown;
            #endregion

            return PartialView("MyModal", asset ?? new AssetDTO());
            //return PartialView("_AddModifyItemModal", asset ?? new AssetDTO()); todo-delete
        }

        //[HttpGet]
        //public IActionResult MyModal(int id, TakeInventoryVM userDetails)
        //{
        //    //when id  = 0, we are adding a new item
        //    //when id != 0, we are modifying an item
        //    AssetDTO asset = _inventoryService.GetAssetById(id);

        //    #region Product drop down
        //    //build Product drop down
        //    List<ProductDTO> products = _inventoryService.GetAllProductsDTO();

        //    List<SelectListItem> productDropdown = new List<SelectListItem>();
        //    foreach (ProductDTO p in products)
        //    {
        //        productDropdown.Add(new SelectListItem() { Text = p.ProductName, Value = p.ProductKey.ToString() });
        //    }

        //    ViewBag.GetProductDropDown = productDropdown;
        //    #endregion

        //    #region Manufacturer drop down
        //    //build Manufacturer drop down
        //    List<ManufacturerDTO> manufacturers = _inventoryService.GetAllManufacturersDTO();

        //    List<SelectListItem> manufacturerDropdown = new List<SelectListItem>();
        //    foreach (ManufacturerDTO m in manufacturers)
        //    {
        //        manufacturerDropdown.Add(new SelectListItem() { Text = m.ManufacturerName, Value = m.ManufacturerKey.ToString() });
        //    }

        //    ViewBag.GetManufacturerDropDown = manufacturerDropdown;
        //    #endregion

        //    #region Model drop down
        //    //build Model drop down
        //    List<ModelDTO> models = _inventoryService.GetAllModelsDTO();

        //    List<SelectListItem> modelDropdown = new List<SelectListItem>();
        //    foreach (ModelDTO m in models)
        //    {
        //        modelDropdown.Add(new SelectListItem() { Text = m.ModelName, Value = m.ModelKey.ToString() });
        //    }

        //    ViewBag.GetModelDropDown = modelDropdown;
        //    #endregion

        //    #region ClientSite Drop Down 
        //    //build client site DropDownList
        //    List<ClientSiteDTO> clientSites = _inventoryService.GetAllClientSites()
        //                                                       .Select(x => new ClientSiteDTO
        //                                                       {
        //                                                           ClientSiteKey = x.ClientSiteKey,
        //                                                           ClientSiteName = x.ClientSiteName
        //                                                       })
        //                                                       .ToList();

        //    List<SelectListItem> clientSiteDropdown = new List<SelectListItem>();
        //    foreach (ClientSiteDTO site in clientSites)
        //    {
        //        clientSiteDropdown.Add(new SelectListItem() { Text = site.ClientSiteName, Value = site.ClientSiteKey.ToString() });
        //    }

        //    ViewBag.GetClientSiteDropDown = clientSiteDropdown;
        //    #endregion

        //    //todo-fix the repeated DropDown code
        //    #region Location Drop Down
        //    List<SelectListItem> locationDropDown = new List<SelectListItem>();
        //    List<Location> locations = _inventoryService.GetAllLocations();

        //    foreach (Location location in locations)
        //    {
        //        locationDropDown.Add(new SelectListItem() { Text = location.LocationName, Value = location.LocationKey.ToString() });
        //    }

        //    ViewBag.GetLocationDropDown = locationDropDown;
        //    #endregion

        //    return View("MyModal", asset ?? new AssetDTO());
        //}


        [HttpPost]
        public IActionResult AddModifyItemModal(int id, AssetDTO asset)
        {
            //if id = 0, so we are adding a new item
            return PartialView("_AddModifyItemModal");

            //id != 0, so we are modifying an item
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            //FriendsInfo frnds = new FriendsInfo();
            //frnds = db.FriendsInfo.Find(Id);
            //return PartialView("_Details", frnds);
            return PartialView("_Details");
        }

    }
}
