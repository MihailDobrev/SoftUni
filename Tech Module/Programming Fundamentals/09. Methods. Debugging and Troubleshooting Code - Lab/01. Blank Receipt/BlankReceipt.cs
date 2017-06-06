namespace Blank_Receipt
{
    using System;
    public class BlankReceipt
    {
        static void Main()
        {
            PrintHeader();
            PrintReceipt();
            PrintFooter();
        }
        public static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        public static void PrintReceipt()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        public static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
    }
}
