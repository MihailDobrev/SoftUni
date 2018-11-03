using System;
using System.ComponentModel.DataAnnotations;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class Report
    {    
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int UserId { get; set; }
        public User Reporter { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

    }
}
