using System.Linq;
using Torshia.Models;

namespace Torshia.Services
{
    public interface IReportService
    {
        Report FindReport(int taskId);

        IQueryable<Report> GetAllReports();
    }
}
