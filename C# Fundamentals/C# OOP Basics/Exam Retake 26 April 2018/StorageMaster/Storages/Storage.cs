using StorageMaster.Products;
using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Storages
{
    public abstract class Storage
    {
        private List<Product> products;

        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            products = new List<Product>();
            this.garage = new Vehicle[garageSlots];
            Array.Copy(vehicles.ToArray(), this.garage, vehicles.ToArray().Length);
        }

        public string Name { get; protected set; }

        public int Capacity { get; protected set; }

        public int GarageSlots { get; protected set; }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => garage;

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot < 0 || garageSlot > GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            
            return garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);
            this.garage[garageSlot] = null;
            int freeGarageSlot = deliveryLocation.CheckForFreeGarageSlot();
            deliveryLocation.garage[freeGarageSlot] = vehicle;
            return freeGarageSlot;
        }

        private int CheckForFreeGarageSlot()
        {
            bool foundIndex = false;
            int freeGarageSlot = -1;

            for (int index = 0; index < this.garage.Length; index++)
            {
                if (garage[index] == null)
                {
                    foundIndex = true;
                    freeGarageSlot = index;
                    break;
                }
            }
            if (foundIndex == false)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            return freeGarageSlot;

        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedProducts = 0;
            while (vehicle.IsEmpty == false && this.IsFull == false)
            {
                Product product = vehicle.Unload();
                unloadedProducts++;
                this.products.Add(product);
            }

            return unloadedProducts;
        }
    }
}
