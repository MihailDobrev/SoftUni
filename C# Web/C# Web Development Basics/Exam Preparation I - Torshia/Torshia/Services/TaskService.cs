using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Torshia.Models;
using Torshia.Models.Enums;
using Toshia.Data;

namespace Torshia.Services
{
    public class TaskService : ITaskService
    {
        private readonly TorshiaContext db;

        public TaskService(TorshiaContext context)
        {
            db = context;
        }

        public IQueryable<Task> All()
         => this.db.Tasks
            .Include(x => x.AffectedSectors);

        public Task FindTask(int id)
        {
            return this.db.Tasks
                .Where(x => x.Id == id)
                .Select(t => new Task
                {
                    Id=t.Id,
                    Title = t.Title,
                    Participants = t.Participants,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    AffectedSectors = t.AffectedSectors.Select(a => new TaskSector
                    {
                        Sector = a.Sector
                    }).ToArray()
                })
                .FirstOrDefault();
        }

        public void ChangeTaskToReportedAndCreateReport(int id, User user)
        {
            Task task = ChangeTaskToReported(id);

            CreateReport(user, task);
        }        

        private void CreateReport(User user, Task task)
        {
            Report report = new Report
            {
                Task = task,
                ReportedOn = DateTime.Now,
                UserId = user.Id,
                Status = this.GetRandomStatus()
            };

            this.db.Reports.Add(report);
            db.SaveChanges();
        }

        private Task ChangeTaskToReported(int id)
        {
            var task = this.db.Tasks.Find(id);

            task.IsReported = true;

            return task;
        }

        private Status GetRandomStatus()
        {
            Random random = new Random();

            int rand = random.Next(0, 100);

            if (rand <= 25)
            {
                return Status.Archived;
            }

            return Status.Completed;
        }

        public void CreateTask(Task task)
        {

            this.db.Tasks.Add(task);
            db.SaveChanges();
        }

        public IQueryable<Task> GetAllReportedTasks()
      => this.db.Tasks
            .Include(x => x.AffectedSectors)
            .Where(t=>t.IsReported);
    }
}
