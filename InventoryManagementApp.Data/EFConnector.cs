using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InventoryManagementApp.Data.Models;

namespace InventoryManagementApp.Data
{
    public class EFConnector
    {
        private readonly InventoryManagementContext _inventoryManagementContext;

        public EFConnector(InventoryManagementContext inventoryManagementContext)
        {
            _inventoryManagementContext = inventoryManagementContext;
        }

        public List<ClientSite> GetAllClientSites()
        {
            List<ClientSite> cs = _inventoryManagementContext.ClientSite
                                                                .ToList();


            #region //this is Sheila's test Linq playground.
            var beatles = (new[] { new { id=1 , inst = "guitar" , name="John" },
                new { id=2 , inst = "guitar" , name="George" },
                new { id=3 , inst = "drums" , name="ringo" },
                new { id=4 , inst = "drums" , name="pete" },
                new { id=5 , inst = "guitar" , name="Paul" },
                new { id=6 , inst = "drums" , name="alan" },  //this is first drum in last group of drums
                new { id=7 , inst = "drums" , name="bernard" },
                new { id=8 , inst = "guitar" , name="Colin" },  //this is the first guitar in the last group of guitars
                new { id=8 , inst = "guitar" , name="Declan" }
            });

            var myOutput = beatles.OrderBy(x => x.id).GroupBy(x => x.inst)  //if i were to just count this i.e. .Count()  output = 2,
                                                                            //however, if I were to do 
                                                                            //.Select(g => new { name = g });
            .Select(g => new { g, count = g.Count() })
            .SelectMany(t => t.g.Select(b => b)
                                .Zip(Enumerable.Range(1, t.count), (j, i) => new { j.inst, j.name, rn = i }));

            int key = 0;
            var output2 = beatles.Select(
                (n, i) => i == 0 ?
                  new { Value = n, Key = key } :
                  new
                  {
                      Value = n,
                      Key = n.inst == beatles[i - 1].inst ? key : ++key
                  })
                .Where(a => a.Value.inst == "guitar")
                .GroupBy(a => a.Key, a => a.Value)
                .OrderBy(a => a.Key)
                .LastOrDefault() //grabs the last sequence of available statuses i.e. Status = 10
                .FirstOrDefault() //grabs the first row of that sequence
                .name;

            //var test = output2.ToList()[0];
            #endregion

            #region use Zip todo-delete
            IEnumerable<Product> products = _inventoryManagementContext.Product.ToArray();
            
            int key2 = 0;
            var prod2 = products.Zip(products.Skip(1), (prev, cur) =>
                {
                    var a = prev.ProductKey;
                    var b = cur.ProductKey;

                    return products.Select((n, i) => i == 0 ?
                                                    new { Value = n, Key = key2
                                                        //,
                                                        //PrevProdKey = a,
                                                        //CurProdKey = b
                                                    } :
                                                    new
                                                    {
                                                        Value = n,
                                                        Key = prev.ProductKey == cur.ProductKey ? key2 : ++key2
                                                        //,
                                                        //PrevProdKey = a
                                                        //,
                                                        //CurProdKey = b
                                                    }
                                           );
                }
                
                //{
                //    return products.Select((prev, i) => new { Value = prev, Key = key2 }
                //                          );
                //}

                //{ 
                //return products.Select((n, i) => i == 0 ?
                //                                new { Value = n, Key = key2 } :
                //                                new
                //                                {
                //                                    Value = n,
                //                                    Key = prev.ProductKey == cur.ProductKey ? key2 : ++key2
                //                                }
                //                      );
                //}
            );

            var prod21 = prod2.Select(a => a.Where(b => b.Value.ProductKey == 5))
                            .Select(a => a.GroupBy(b => b.Key))
                            .Select(a => a.OrderBy(b => b.Key));
            #endregion  todo-delete this is test code 

            #region 
            int key3 = 0;
            var prod3 = products.Select(prev => new 
                                                {
                                                    prod4 = products.Select((cur, i) => i == 0 ?
                                                                                            new { Value = cur, Key = key3 } :
                                                                                            new {
                                                                                                Value = cur,
                                                                                                Key = prev.ProductKey == cur.ProductKey ? key3 : ++key3
                                                                                            }
                                                                           )
                                                }
                                       );
            //the issue with this prod3 is that it looks twice, and compares each key to each other key, which is way too many comparisons when all I want to do is comare a row to the row directly above
            #endregion

            #region
            int key4 = 0;
            int productKey = 5;
            var prod5 = products.Any(a => a.ProductKey == productKey) ?                                           //there is at least 1 record with Status = 10 i.e.  
                (products.Where(a => a.ProductKey == productKey).Count() == 1 ?  //there's only 1 record with Status = 10(need to check this before I use .Zip because .Zip throws exception when there's less than two records)
                products.SingleOrDefault(a => a.ProductKey == 1).ProductId :
                products.Zip(products.Skip(1), (prev, cur) =>
            {
                return new
                {
                    Value = cur,
                    Key = prev.ProductKey == cur.ProductKey ? key4  : ++key4
                };
            })
                .Where(a => a.Value.ProductKey == productKey)
                .GroupBy(a => a.Key)
                .OrderBy(a => a.Key)
                .LastOrDefault() //grabs the last sequence of available statuses i.e. Status = 10
                .FirstOrDefault() //grabs the first row of that sequence
                .Value.ProductId) :
                products.OrderBy(a => a.ProductKey).FirstOrDefault().ProductId
                
                ;
            #endregion

             return cs;
        }

        public List<Location> GetAllLocations()
        {
            List<Location> locations = _inventoryManagementContext.Location
                                                                    .ToList();
            return locations;
        }

        public Asset GetAssetById(int id)
        {
            Asset asset = _inventoryManagementContext.Asset
                                                     .Include(a => a.Product)
                                                     .Include(a => a.Manuafcturer)
                                                     .Include(a => a.Model)
                                                     .SingleOrDefault(a => a.AssetKey == id);

            return asset;
        }

        public void SaveNewAsset(Asset asset)
        {
            _inventoryManagementContext.Asset.Add(asset);
            _inventoryManagementContext.SaveChanges();
        }


        public List<Product> GetAllProducts()
        {
            List<Product> products = _inventoryManagementContext.Product
                                                                .ToList();
            return products;
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            List<Manufacturer> manufacturers = _inventoryManagementContext.Manufacturer
                                                                .ToList();
            return manufacturers;
        }

        public List<Model> GetAllModels()
        {
            List<Model> models = _inventoryManagementContext.Model
                                                                .ToList();
            return models;
        }

    }//here's a helpful command to propagate DB updates. dotnet ef dbcontext scaffold "Server=USC-W-6990M13\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
}
