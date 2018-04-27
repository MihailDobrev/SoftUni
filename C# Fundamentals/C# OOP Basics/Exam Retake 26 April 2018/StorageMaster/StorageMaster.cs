using StorageMaster.Factories;
using StorageMaster.Products;
using StorageMaster.Storages;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    public class StorageMaster
    {
        private List<Product> productPool;
        private List<Storage> storageRegistry;
        private Vehicle currentVehicle;
        public StorageMaster()
        {
            productPool = new List<Product>();
            storageRegistry = new List<Storage>();
        }
        
        public string AddProduct(string type, double price)
        {
            ProductFactory productFactory = new ProductFactory();
            Product product = productFactory.CreateProduct(type, price);
            productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            StorageFactory storageFactory = new StorageFactory();
            Storage storage = storageFactory.CreateStorage(type, name);
            storageRegistry.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            this.currentVehicle = storage.GetVehicle(garageSlot);
            return $"Selected {this.currentVehicle.Type}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            int productCount = productNames.ToArray().Length;

            foreach (var product in productNames)
            {
                if (this.productPool.Any(p => p.Name == product))
                {
                    Product productFound = productPool.Last(p => p.Name == product);
                    int index = productPool.LastIndexOf(productFound);
                    productPool.RemoveAt(index);

                    if (!currentVehicle.IsFull)
                    {
                        currentVehicle.LoadProduct(productFound);
                        loadedProductsCount++;
                    }
                    else
                    {
                        return $"Loaded {loadedProductsCount}/{productCount} products into {currentVehicle.Type}";
                    }
                }
                else
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }
            }

            return $"Loaded {loadedProductsCount}/{productCount} products into {currentVehicle.Type}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            Storage destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name == destinationName);

            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);


            return $"Sent {vehicle.Type} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            double totalProductWeight = storage.Products.Sum(p => p.Weight);
            int storageCapacity = storage.Capacity;
            
            List<string> sortedProducts = new List<string>();
            var sortedGroupedProducts = storage.Products.GroupBy(i => i.Name);
            foreach (var grp in sortedGroupedProducts.OrderByDescending(x=>x.Count()).ThenBy(x=>x.Key))
            {
                string name = grp.Key;
                int total = grp.Count();
                sortedProducts.Add($"{name} ({total})");
            }
            
            var sortedVehicles = storage.Garage.Select(g => g == null ? "empty" : $"{g.Type}");

            string result = $"Stock ({totalProductWeight}/{storageCapacity}): [{string.Join(", ",sortedProducts)}]";
            result += Environment.NewLine + $"Garage: [{string.Join('|', sortedVehicles)}]";

            return result;
        }

        public string GetSummary()
        {
            var storageInfos = storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Price)).Select(s => $"{s.Name}:" + Environment.NewLine + $"Storage worth: ${s.Products.Sum(p => p.Price):F2}").ToArray();
            StringBuilder sb = new StringBuilder();

            foreach (var storageInfo in storageInfos)
            {
                sb.AppendLine(storageInfo);
            }

            return sb.ToString().Trim();
        }

    }
}
