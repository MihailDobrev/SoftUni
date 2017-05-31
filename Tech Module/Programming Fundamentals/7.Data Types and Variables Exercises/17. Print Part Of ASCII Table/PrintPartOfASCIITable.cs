

namespace _17_Print_Part_Of_ASCII_Table
{
    using System;

    public class PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int IndexBegin = int.Parse(Console.ReadLine());
            int IndexEnd = int.Parse(Console.ReadLine());
            char charIndexBegin = (char)IndexBegin;
            char charIndexEnd = (char)IndexEnd;

            for (char i = charIndexBegin; i <=charIndexEnd; i++)
            {
                char indexPrint = i;
                Console.Write(indexPrint+" ");
            }
            
        }
    }
}
