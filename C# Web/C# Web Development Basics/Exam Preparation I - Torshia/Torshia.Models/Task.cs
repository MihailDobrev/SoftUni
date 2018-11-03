using System;
using System.Collections.Generic;

namespace Torshia.Models
{
    public class Task
    {
        public Task()
        {
            AffectedSectors = new HashSet<TaskSector>();
            Reports = new HashSet<Report>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public ICollection<Report> Reports { get; set; }

        public ICollection<TaskSector> AffectedSectors { get; set; }
    }
}
