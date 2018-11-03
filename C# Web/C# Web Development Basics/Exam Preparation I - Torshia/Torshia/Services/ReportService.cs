using System.Linq;
using Torshia.Models;
using Toshia.Data;

namespace Torshia.Services
{
    public class ReportService : IReportService
    {

        private readonly TorshiaContext db;

        public ReportService(TorshiaContext context)
        {
            db = context;
        }

        public Report FindReport(int taskId)
        {
            return this.db.Reports
                .FirstOrDefault(r => r.TaskId == taskId);
        }

        public IQueryable<Report> GetAllReports()
        {
            return this.db.Reports;
        }


    }
}
