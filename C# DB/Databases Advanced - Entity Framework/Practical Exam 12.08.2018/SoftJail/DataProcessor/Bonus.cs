namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Linq;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners.FirstOrDefault(p => p.Id == prisonerId);

            var releaseDate = prisoner.ReleaseDate;

            if (releaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }

            prisoner.ReleaseDate = DateTime.Now;
            prisoner.CellId = null;
            context.SaveChanges();
            return $"Prisoner {prisoner.FullName} released";
        }
    }
}
