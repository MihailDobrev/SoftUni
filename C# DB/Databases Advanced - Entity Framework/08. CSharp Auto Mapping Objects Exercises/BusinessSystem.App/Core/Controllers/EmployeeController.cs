namespace BusinessSystem.App.Core.Controllers
{
    using AutoMapper;
    using BusinessSystem.App.Core.Contracts;
    using BusinessSystem.App.Core.Dtos;
    using BusinessSystem.Data;
    using BusinessSystem.Models;
    using System;
    using System.Linq;

    public class EmployeeController : IEmployeeController
    {
        private readonly BusinessSystemContext context;
        private readonly IMapper mapper;

        public EmployeeController(BusinessSystemContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {

            var employee = context.Employees.Find(employeeId);

            var employeeDto = mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public EmployeeDto[] ListEmployeesOlderThan(int age)
        {
            var employees = context.Employees
                .Where(e => DateTime.Now.Year - e.Birthday.Value.Year > age)
                .OrderByDescending(e => e.Salary);

            EmployeeDto[] employeesDto = mapper.Map<EmployeeDto[]>(employees);

            return employeesDto;
        }

        public EmployeeInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeInfoDto = mapper.Map<EmployeeInfoDto>(employee);

            return employeeInfoDto;
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Address = address;

            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Birthday = date;

            context.SaveChanges();
        }
    }
}
