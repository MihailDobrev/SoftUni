using StorageMaster.Vehicles;

namespace StorageMaster.Storages
{
    public class Warehouse : Storage
    {
        public Warehouse(string name) 
            : base(name, 10, 10, new Vehicle[] { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}
