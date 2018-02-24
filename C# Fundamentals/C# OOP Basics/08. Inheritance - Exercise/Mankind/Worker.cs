namespace Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double weekHoursPerDay)
            : base(firstName, lastName)
        {
            WorkHoursPerDay = weekHoursPerDay;
            WeekSalary = weekSalary;
        }

        public double WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
                }
                workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
                }
                weekSalary = value;
            }
        }

        public decimal CalculateSalaryPerHour()
        {
            return this.WeekSalary / 5 / (decimal)this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString())
                .AppendLine($"Week Salary: {this.weekSalary:F2}")
                .AppendLine($"Hours per day: {this.workHoursPerDay:F2}")
                .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():F2}");

            return sb.ToString();
        }
    }
}
