using System;
using System.Collections.Generic;
using System.Text;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class TaskSector
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }

        public Sector  Sector { get; set; }
    }
}
