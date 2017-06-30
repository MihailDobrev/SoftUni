namespace _06.EXCELlent_Knowledge
{
    using System;
    using Microsoft.Office.Interop.Excel;
    public class EXCELlentKnowledge
    {
        static void Main()
        {
            Application excelApp = new Application();
            Workbook excelWorkbook = excelApp
                .Workbooks
                .Open(@"D:\SoftUni\Objects, Classes, Files and Exceptions - More Exercises\06. EXCELlent Knowledge\sample_table.xlsx");
            Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            Range excelRange = excelWorksheet.UsedRange;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (j == 1 && i != 1)
                    {
                        Console.WriteLine();
                    }

                    Console.Write(excelRange.Cells[i, j].Value + "|");
                }
            }
        }
    }
}
