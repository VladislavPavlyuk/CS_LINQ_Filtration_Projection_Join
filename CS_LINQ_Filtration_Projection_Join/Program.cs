/*
 Фильтрация. Проецирование. Объединение.

1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе.
2) Вывести список стран без повторений.
3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.
4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года.
 */

using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" }, 
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" }, 
                new Department(){ Id = 3, Country = "France", City = "Paris" }, 
                new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 }, 
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 }, 
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 }, 
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 }, 
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 }, 
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 }, 
                new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
            };

            //1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе.

            Console.WriteLine("\nВыбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе.\n");

            var employee1 = from employee in employees
                            from department in departments
                            where employee.DepId == department.Id &&
                            department.Country == "Ukraine" &&
                                department.City != "Odesa"
                            select new { First = employee.FirstName, Last = employee.LastName };
            foreach (var e in employee1)
                Console.WriteLine("{0} - {1}", e.First, e.Last);
            Console.WriteLine('\n');

            //2) Вывести список стран без повторений

            Console.WriteLine("\nВывести список стран без повторений\n");

            var countries = from department in departments
                         select new { Country = department.Country };

            var result = countries.Distinct();
            foreach (var c in result)
                Console.WriteLine(c.Country);
            Console.WriteLine('\n');

            //3) Выбрать 3 - x первых сотрудников, возраст которых превышает 25 лет.

            Console.WriteLine("\nВыбрать 3 - x первых сотрудников, возраст которых превышает 25 лет.\n");

            var employee2 = from employee in employees
                            from department in departments
                            where employee.DepId == department.Id &&
                            employee.Age > 25 
                            select new { First = employee.FirstName, Last = employee.LastName };

            employee2 = employee2.Take(3);

            foreach (var e in employee2)
                Console.WriteLine("{0} - {1}", e.First, e.Last);

            Console.WriteLine('\n');
            //4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года.

            Console.WriteLine("\nВыбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года\n");


            var employee3 = from employee in employees
                            from department in departments
                            where employee.DepId == department.Id &&
                            employee.Age > 25 &&
                            department.City == "Kyiv"
                            select new { First = employee.FirstName, Last = employee.LastName, Age = employee.Age };

            foreach (var e in employee3)
                Console.WriteLine("{0} - {1} - {2}", e.First, e.Last, e.Age);

            Console.WriteLine('\n');
        }
    }
}