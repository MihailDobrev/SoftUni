using System;
using System.Linq;

namespace StorageMaster
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            storageMaster = new StorageMaster();
        }
        public void Run()
        {
            string input;

            while ((input=Console.ReadLine())!="END")
            {
                string[] args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string commmandName = args[0];
                string result = string.Empty;

                try
                {
                    switch (commmandName)
                    {
                        case "AddProduct":
                            string type1 = args[1];
                            double price = double.Parse(args[2]);
                            result += storageMaster.AddProduct(type1, price);
                            break;
                        case "RegisterStorage":
                            string type2 = args[1];
                            string name = args[2];
                            result += storageMaster.RegisterStorage(type2, name);
                            break;
                        case "SelectVehicle":
                            string storageName = args[1];
                            int garageSlot = int.Parse(args[2]);
                            result += storageMaster.SelectVehicle(storageName, garageSlot);
                            break;
                        case "LoadVehicle":
                            args = args.Skip(1).ToArray();
                            result += storageMaster.LoadVehicle(args);
                            break;
                        case "SendVehicleTo":
                            string sourceName = args[1];
                            int sourceGarageSlot = int.Parse(args[2]);
                            string destinationName = args[3];
                            result += storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            break;
                        case "UnloadVehicle":
                            string storageName2 = args[1];
                            int garageSlot2 = int.Parse(args[2]);
                            result += storageMaster.UnloadVehicle(storageName2, garageSlot2);
                            break;
                        case "GetStorageStatus":
                            string storageName3 = args[1];
                            result += storageMaster.GetStorageStatus(storageName3);
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Error: "+ ioe.Message);
                }

                if (result!=string.Empty)
                {
                    Console.WriteLine(result);
                }
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}