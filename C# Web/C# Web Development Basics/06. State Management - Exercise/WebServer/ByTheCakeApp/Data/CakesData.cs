namespace WebServer.ByTheCakeApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ByTheCakeApp.Models;

    public class CakesData
    {
        private const string databaseFile = @"..\..\..\ByTheCakeApp\Data\database.csv";

        public IEnumerable<Cake> All()
        {
            return File
                   .ReadAllLines(databaseFile)
                   .Where(l => l.Contains(','))
                   .Select(l => l.Split(','))
                    .Select(l => new Cake
                    {
                        Id = int.Parse(l[0]),
                        Name = l[1],
                        Price = decimal.Parse(l[2])
                    });
        }

        public void Add(string name, string price)
        {
            var streamreader = new StreamReader(databaseFile);
            var id = streamreader.ReadToEnd().Split(Environment.NewLine).Length;
            streamreader.Dispose();

            using (var streamwriter = new StreamWriter(databaseFile, true))
            {
                streamwriter.WriteLine($"{id},{name},{price}");
            }
        }

        public Cake Find(int id) => this.All().FirstOrDefault(c => c.Id == id);

    }
}
