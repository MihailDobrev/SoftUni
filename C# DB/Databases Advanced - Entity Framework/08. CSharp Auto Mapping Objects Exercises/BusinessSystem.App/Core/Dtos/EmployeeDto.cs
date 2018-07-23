namespace BusinessSystem.App.Core.Dtos
{
    using BusinessSystem.Models;

    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public Employee Manager { get; set; }
    }
}
