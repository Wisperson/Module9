using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module9
{
    public class HomeWork
    {
        static public void Start()
        {
            Random random = new Random();
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    employees.Add(new Manager("Ivan", random.Next(100000, 200000), Math.Round(random.NextDouble(), 2)));
                }
                else
                {
                    employees.Add(new Developer("Sergey", random.Next(300000, 1000000), random.Next(100, 1000)));
                }
            }
            foreach (Employee emp in employees)
            {
                emp.CalculateAnnualSalary();
            }

        }

        public class Employee
        {
            public string Name { get; set; }
            public int Salary { get; set; }
            public virtual void CalculateAnnualSalary()
            {
                Console.WriteLine(Salary);
            }
            public Employee(string name, int salary)
            {
                Name = name;
                Salary = salary;
            }
        }

        public class Manager: Employee
        {
            public double Bonus { get; set; }
            public override void CalculateAnnualSalary()
            {
                Console.WriteLine(GetType().Name + ":" + Salary * (1 + Bonus));
            }
            public Manager (string name, int salary, double bonus) : base(name, salary)
            {
                Bonus = bonus;
            }
        }

        public class Developer: Employee
        {
            public int LinesOfCodePerDay { get; set; }
            public override void CalculateAnnualSalary()
            {
                Console.WriteLine(GetType().Name + ":" + (Salary + Salary * 0.000001 * LinesOfCodePerDay));
            }
            public Developer (string name, int salary, int lines) : base(name, salary)
            {
                LinesOfCodePerDay = lines;
            }
        }
    }
}
