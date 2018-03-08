namespace _04.Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string site)
        {
            if (site.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {site}!";
        }

        public string Call(string number)

        {
            if (number.Any(d => !char.IsDigit(d)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }

    }
}
