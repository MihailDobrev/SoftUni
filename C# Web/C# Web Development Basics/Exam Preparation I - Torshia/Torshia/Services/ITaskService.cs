using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torshia.Models;

namespace Torshia.Services
{
    public interface ITaskService
    {
        IQueryable<Task> All();

        Task FindTask(int id);

        void ChangeTaskToReportedAndCreateReport(int id, User user);
        void CreateTask(Task task);

        IQueryable<Task> GetAllReportedTasks();
    }
}
