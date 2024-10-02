using System;
using System.Collections.Generic;


namespace ConsoleApp4
{
    public class Employee
    {
        private string? name;
        private string? email;
        private string? department;
        private int salary;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Invalid email address.");
                }
                email = value;
            }
        }

        public string Department
        {
            get { return department; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Department cannot be empty.");
                }
                department = value;
            }
        }

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }
                salary = value;
            }
        }

        public Employee(string name, string email, string department, int salary)
        {
            Name = name;
            Email = email;
            Department = department;
            Salary = salary;
        }

        public static Employee operator +(Employee empl, int increase)
        {
            empl.Salary += increase;
            return empl;
        }

        public static Employee operator -(Employee empl, int decrease)
        {
            empl.Salary -= decrease;
            if (empl.Salary < 0)
            {
                empl.Salary = 0; 
            }
            return empl;
        }

        public static bool operator ==(Employee empl1, Employee empl2)
        {
            return empl1.Salary == empl2.Salary;
        }

        public static bool operator !=(Employee empl1, Employee empl2)
        {
            return !(empl1 == empl2);
        }

        public static bool operator <(Employee empl1, Employee empl2)
        {
            return empl1.Salary < empl2.Salary;
        }

        public static bool operator >(Employee empl1, Employee empl2)
        {
            return empl1.Salary > empl2.Salary;
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee emp)
            {
                return Salary == emp.Salary;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Salary.GetHashCode();
        }

        public override string ToString()
        {
            return $"Employee: {Name}, Email: {Email}, Department: {Department}, Salary: {Salary} GRN";
        }
    }
}
