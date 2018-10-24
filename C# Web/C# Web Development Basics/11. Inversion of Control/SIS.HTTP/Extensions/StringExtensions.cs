namespace SIS.HTTP.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException($"{nameof(word)} cannot be null!");
            }

            return string.Concat(char.ToUpper(word[0]), word.Substring(1).ToLower());
        }
    }
}
