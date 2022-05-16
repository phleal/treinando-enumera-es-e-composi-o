using System;
using System.Globalization;
using Treinando_Enumerações_E_Composição.Entities.Enums;
using Treinando_Enumerações_E_Composição.Entities;


namespace Treinando_Enumerações_E_Composição
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker date: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department dept = new Department(deptName);

            Worker woker = new Worker(name, level, baseSalary, dept);


            Console.Write("How many contracs for this Worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                woker.AddContract(contract);
            }


            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));

            int year = int.Parse(monthAndYear.Substring(3));


            Console.WriteLine("Name: " + woker.Name);
            Console.WriteLine("Department: " + woker.Department.Name);
            Console.WriteLine("Income for: " + monthAndYear + ": " + woker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
