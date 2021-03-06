﻿public class Employee
{
    private string name;
    private double salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, double salary, string position, string department, string email, int age)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = email;
        Age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

}


