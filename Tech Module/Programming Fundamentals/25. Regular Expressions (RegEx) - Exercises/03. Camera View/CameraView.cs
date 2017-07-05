namespace _03.Camera_View
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class CameraView
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split();
            int skip = int.Parse(elements[0]);
            int take = int.Parse(elements[1]);
            var str = Console.ReadLine();
            var pattern = $@"(?<=\|<\w{{{skip}}})\w{{0,{take}}}";
            var matches = Regex.Matches(str, pattern);
            var views = new List<string>();

            foreach (Match match in matches)
            {
                views.Add(match.Value);
            }

            Console.WriteLine(string.Join(", ", views));
        }
    }
}

