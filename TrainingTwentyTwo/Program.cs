using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using TrainingTwentyTwo.Entities;


namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter salary limit: ");
            double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee (name, email, salary));
                }
                Console.WriteLine();
                var e1 = list.Where(p => p.Salary > limit).OrderBy(p => p.Email).Select(p => p.Email);
                var s1 = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                var n1 = list.Where(p => p.Name[0] == 'M').Select(p => p.Name);

                Console.WriteLine("Email of people whose salary is more than " + limit.ToString("F2", CultureInfo.InvariantCulture));
                foreach (string email in e1)
                {
                    Console.WriteLine(email);
                }
                Console.WriteLine();

                Console.WriteLine("Names of people whose name starts with 'M': ");
                foreach (string name in n1)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + s1.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}