namespace _04.Telephony
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            Smartphone smarthphone = new Smartphone();
            CallNumbers(smarthphone);
            BrowseSites(smarthphone);         
        }

        private static void BrowseSites(Smartphone smarthphone)
        {
            string[] sites = Console.ReadLine().Split();

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smarthphone.Browse(site));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void CallNumbers(Smartphone smarthphone)
        {
            string[] phoneNumbers = Console.ReadLine().Split();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smarthphone.Call(phoneNumber));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
