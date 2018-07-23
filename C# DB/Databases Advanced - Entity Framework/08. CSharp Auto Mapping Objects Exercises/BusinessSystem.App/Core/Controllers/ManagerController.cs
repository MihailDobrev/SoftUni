namespace BusinessSystem.App.Core.Controllers
{
    using BusinessSystem.App.Core.Contracts;
    using BusinessSystem.App.Core.Dtos;
    using BusinessSystem.Data;
    using BusinessSystem.Models;
    using System;
    using System.Linq;
    using AutoMapper;

    public class ManagerController : IManagerController
    {
        private readonly BusinessSystemContext context;
        private readonly IMapper mapper;
        public ManagerController(BusinessSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ManagerDto ManagerInfo(int employeeId)
        {
            var manager = context.Employees
                 .Where(e => e.Id == employeeId)
                 .FirstOrDefault();

            var managerDto = mapper.Map<ManagerDto>(manager);

            if (managerDto == null)
            {
                throw new ArgumentException("Invalid manager id");
            }

            return managerDto;
        }

        public void SetManager(int employeeId, int managerId)
        {
            Employee employee = this.context.Employees.Find(employeeId);

            Employee manager = this.context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee Id");
            }

            employee.Manager = manager ?? throw new ArgumentException("Invalid manager Id");
            context.SaveChanges();
        }
    }
}
