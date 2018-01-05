using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJudge
{
    public class JudgeStartup
    {
        static void Main()
        {
            Tester.CompareContent(@"C:\Users\User\Desktop\BashSoft-FirstWeek\03. CSharp-Advanced-Files-And-Directories-Lab\test2.txt",
                                    @"C:\Users\User\Desktop\BashSoft-FirstWeek\03. CSharp-Advanced-Files-And-Directories-Lab\test3.txt");
        }
    }
}
