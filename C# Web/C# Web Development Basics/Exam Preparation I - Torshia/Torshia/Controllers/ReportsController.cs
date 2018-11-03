using SIS.Framework.ActionResults;
using System.Collections.Generic;
using System.Linq;
using Torshia.Models;
using Torshia.Services;
using Torshia.ViewModels;

namespace Torshia.Controllers
{
    public class ReportsController:BaseController
    {
        private IReportService reportService;
        private ITaskService taskService;
        private IUserService userService;

        public ReportsController(IReportService reportService, ITaskService taskService, IUserService userService)
        {
            this.reportService = reportService;
            this.taskService = taskService;
            this.userService = userService;
        }

        public IActionResult All()
        {
            if (!this.IsAuthenticated())
            {
                return RedirectToAction("/users/login");
            }

            if (!this.IsAdmin())
            {
                return RedirectToAction("/users/login");
            }

            var reportedTasks = this.taskService.GetAllReportedTasks();

            List<ReportedTasksViewModel> reportedTasksViewModels = new List<ReportedTasksViewModel>();

            int counter = 0;

            foreach (var reportedTask in reportedTasks)
            {
                counter++;
                var report = this.reportService.FindReport(reportedTask.Id);

                var reportsAllViewModel = new ReportedTasksViewModel
                {
                    Level = reportedTask.AffectedSectors.Count,
                    Number= counter,
                    ReportId= reportedTask.Id,
                    Status=report.Status.ToString("g"),
                    Task= reportedTask.Title
                 
                };

                reportedTasksViewModels.Add(reportsAllViewModel);
            }          

            this.Model.Data["ReportedTasksViewModels"] = reportedTasksViewModels;

            return this.View();
        }
         

        public IActionResult Details(int taskId)
        {
            if (!this.IsAuthenticated())
            {
                return RedirectToAction("/users/login");
            }

            if (!this.IsAdmin())
            {
                return RedirectToAction("/users/login");
            }

            Report report = this.reportService.FindReport(taskId);
            User user = this.userService.FindUserById(report.UserId);
            Task task = this.taskService.FindTask(report.TaskId);


            var reportDetailsViewModel = new ReportDetailsViewModel
            {
                Id=task.Id,
                Title = task.Title,
                Description = task.Description,
                AffectedSectors = string.Join(",", task.AffectedSectors.Select(x => x.Sector)),
                DueDate = task.DueDate.ToShortDateString(),
                Level = task.AffectedSectors.Count,
                Participants = task.Participants,
                Reporter = user.Username,
                ReportedOn = report.ReportedOn.ToShortTimeString(),
                Status = report.Status.ToString("g")
            };

            this.Model.Data["ReportDetailsViewModel"] = reportDetailsViewModel;

            return this.View();
        }
    }
}
