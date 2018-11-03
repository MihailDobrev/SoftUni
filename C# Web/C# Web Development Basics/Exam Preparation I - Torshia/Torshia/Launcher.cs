using SIS.Framework;
using System.Collections.Generic;
using Torshia.Models;
using Torshia.Models.Enums;
using Toshia.Data;

namespace Torshia
{
    public class Launcher
    {
        public static void Main()
        {
            //SeedTasks();
            WebHost.Start(new StartUp());
        }

        private static void SeedTasks()
        {
            var db = new TorshiaContext();
            for (int i = 1; i <= 10; i++)
            {
                db.Tasks.Add(new Task
                {
                    Title = $"Fix Business Agenda{i}",
                    DueDate = new System.DateTime(2019 + i, 09, 11 + i),
                    Description = $"The business agaenda of the company needs to be rethought.{i}",
                    Participants = $"Todor Ivanov{i}, Jordan Draganov{i}, Dimitar Stefanov{i}",
                    AffectedSectors = new List<TaskSector>()
                {
                   new TaskSector(){ Sector= Sector.Management},
                   new TaskSector(){ Sector=Sector.Finances },
                   new TaskSector(){ Sector=Sector.Management },
                   new TaskSector(){ Sector=Sector.Internal}
                }
                });
            }

            db.SaveChanges();
        }
    }
}
