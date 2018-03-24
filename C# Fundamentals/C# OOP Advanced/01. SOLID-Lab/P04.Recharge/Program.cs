namespace P04.Recharge
{
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Worker robot = new Robot("robot1", 0);
            Worker employee = new Employee("10");
            ISleeper developer = new Employee("10");
            IRechargeable rechargable  = new Robot("10",0);
            List<IRechargeable> rechargables = new List<IRechargeable>() { rechargable };
            RechargeStation rs = new RechargeStation(rechargables);
        }
    }
}
