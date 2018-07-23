namespace BusinessSystem.App.Core.Contracts
{
    using BusinessSystem.App.Core.Dtos;
    using System;

    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto emplyeeDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeeInfoDto GetEmployeePersonalInfo(int employeeId);

        EmployeeDto[] ListEmployeesOlderThan(int age);
    }
}
