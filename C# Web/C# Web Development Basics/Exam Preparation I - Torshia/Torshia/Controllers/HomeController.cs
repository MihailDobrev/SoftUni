using SIS.Framework.ActionResults;
using System.Collections.Generic;
using Torshia.Services;
using Torshia.ViewModels;

namespace Torshia.Controllers
{
    public class HomeController : BaseController
    {
        private ITaskService taskService;

        public HomeController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            var tasks = this.taskService.All();

            var taskViewModels = new List<TaskViewModel>();

            foreach (var task in tasks)
            {
                taskViewModels.Add(new TaskViewModel
                {
                    Id = task.Id,
                    Title = task.Title,
                    Level = task.AffectedSectors.Count
                });
            }

            this.Model.Data["TaskViewModels"] = taskViewModels;

            return this.View();
        }
    }
}
