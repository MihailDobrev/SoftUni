using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Torshia.Models;
using Torshia.Models.Enums;
using Torshia.Services;
using Torshia.ViewModels;

namespace Torshia.Controllers
{
    public class TasksController : BaseController
    {
        private ITaskService taskService;
        private IUserService userService;

        public TasksController(ITaskService taskService,IUserService userService)
        {
            this.taskService = taskService;
            this.userService = userService;
        }

        public IActionResult Details(int id)
        {
            if (!this.IsAuthenticated())
            {
                return RedirectToAction("/");
            }

            Task task = this.taskService.FindTask(id);

            var taskDetailsViewModel = new TaskDetailsViewModel
            {
                Title = task.Title,
                Level = task.AffectedSectors.Select(a => a.Sector).Count(),
                DueDate = task.DueDate.ToString("dd/MM/yyy", CultureInfo.InvariantCulture),
                Participants = task.Participants,
                AffectedSectors = string.Join(", ", task.AffectedSectors.Select(s => s.Sector)),
                Description = task.Description
            };

            this.Model.Data["TaskDetailsViewModel"] = taskDetailsViewModel;

            return this.View();
        }

        public IActionResult Report(int id)
        {
            if (!this.IsAuthenticated())
            {
                return RedirectToAction("/users/login");
            }

           User user= this.userService.FindUser(this.Identity.Username);
           this.taskService.ChangeTaskToReportedAndCreateReport(id, user);

           return RedirectToAction("/");
        }

        public IActionResult Create()
        {
            if (!this.IsAuthenticated())
            {
                return RedirectToAction("/users/login");
            }
            if (!this.IsAdmin())
            {
                return RedirectToAction("/users/login");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(TaskCreateViewModel model)
        {
            if (!this.IsAuthenticated())
            {
                return RedirectToAction("/users/login");
            }
            if (!this.IsAdmin())
            {
                return RedirectToAction("/users/login");
            }

            var affectedSectors = new List<TaskSector>();
            var sectors = model.AffectedSectors.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var sector in sectors)
            {
                var sectorValue = (Sector)Enum.Parse(typeof(Sector), sector);
                affectedSectors.Add(new TaskSector() { Sector = sectorValue });
            }
            Task task = new Task
            {
                AffectedSectors = affectedSectors,
                Description = this.DecodeString(model.Description),
                DueDate = DateTime.Parse(model.DueDate),
                Participants = this.DecodeString(model.Participants),
                Title = this.DecodeString(model.Title)
            };

            this.taskService.CreateTask(task);

            return this.RedirectToAction("/");
        }
    }
}
