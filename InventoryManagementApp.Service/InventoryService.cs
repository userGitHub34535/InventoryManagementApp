using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagementApp.Data;
using InventoryManagementApp.Data.Models;

namespace InventoryManagementApp.Service
{
    public class InventoryService
    {
        private EFConnector _eFConnector;

        public InventoryService(EFConnector eFConnector)
        {
            _eFConnector = eFConnector;
        }

        public List<ClientSiteDTO> GetAllClientSites()
        {
            List<ClientSite> clientSites = _eFConnector.GetAllClientSites();
            List<ClientSiteDTO> clientSiteDTOs = new List<ClientSiteDTO>();

            foreach (ClientSite site in clientSites) 
            {
                ClientSiteDTO clientSiteDTO = new ClientSiteDTO
                {                    
                    ClientSiteKey = site.ClientSiteKey,
                    ClientSiteName = site.ClientSiteName
                };
                clientSiteDTOs.Add(clientSiteDTO);
            }

            return clientSiteDTOs;
        }

        public List<Location> GetAllLocations()
        {
            return _eFConnector.GetAllLocations();
        }

        public AssetDTO GetAssetById(int id)
        {
            Asset asset = _eFConnector.GetAssetById(id);

            if (asset != null)
            {
                AssetDTO assetDTO = new AssetDTO()
                {
                    AssetKey = asset.AssetKey,
                    ClientSite = asset.ClientSite,
                    ClientSiteId = asset.ClientSiteId,
                    InventoriedBy = asset.InventoriedBy,
                    InventoryDate = asset.InventoryDate,
                    InventoryOwner = asset.InventoryOwner,
                    IsDisposed = asset.IsDisposed,
                    ItemName = asset.ItemName,
                    Location = asset.Location,
                    LocationId = asset.LocationId,
                    Manuafcturer = asset.Manuafcturer,
                    ManuafcturerId = asset.ManuafcturerId,
                    Model = asset.Model,
                    ModelId = asset.ModelId,
                    Product = asset.Product,
                    ProductId = asset.ProductId,
                    PurchaseDate = asset.PurchaseDate,
                    SerialNumber = asset.SerialNumber
                };
                return assetDTO;
            } else
            {
                return null;
            }
        }

        public void AddModifyItemModal(AssetDTO assetDTO)
        {
            //todo-this will create the dialogue on p 14 of srs
        }




        public Asset SaveNewAsset(AssetDTO assetDTO)
        {
            Asset asset = new Asset()
            {
                AssetKey = assetDTO.AssetKey,
                ClientSiteId = assetDTO.ClientSiteId,
                LocationId = assetDTO.LocationId,
                InventoryOwner = assetDTO.InventoryOwner
            };

            _eFConnector.SaveNewAsset(asset);

            return asset;
        }

        public List<ProductDTO> GetAllProductsDTO()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            List<Product> products = _eFConnector.GetAllProducts();

            foreach(Product p in products)
            {
                ProductDTO productDTO = new ProductDTO()
                {
                    ProductKey = p.ProductKey,
                    ProductName = p.ProductName
                };

                productDTOs.Add(productDTO);
            }

            return productDTOs;
        }

        public List<ModelDTO> GetAllModelsDTO()
        {
            List<ModelDTO> modelDTOs = new List<ModelDTO>();
            List<Model> models = _eFConnector.GetAllModels();

            foreach (Model m in models)
            {
                ModelDTO ModelDTO = new ModelDTO()
                {
                    ModelKey = m.ModelKey,
                    ModelName = m.ModelName
                };

                modelDTOs.Add(ModelDTO);
            }

            return modelDTOs;
        }

        public List<ManufacturerDTO> GetAllManufacturersDTO()
        {
            List<ManufacturerDTO> manufacturerDTOs = new List<ManufacturerDTO>();
            List<Manufacturer> manufacturers = _eFConnector.GetAllManufacturers();

            foreach (Manufacturer m in manufacturers)
            {
                ManufacturerDTO ManufacturerDTO = new ManufacturerDTO()
                {
                    ManufacturerKey = m.ManufacturerKey,
                    ManufacturerName = m.ManufacturerName
                };

                manufacturerDTOs.Add(ManufacturerDTO);
            }

            return manufacturerDTOs;
        }
    }
}
