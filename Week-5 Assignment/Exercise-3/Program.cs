

using SalaryCalculator;

namespace Exercise_3
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.Write("Enter Basic Salary: ");
                    double basicSalary = double.Parse(Console.ReadLine());

                    double netSalary = Salary.CalculateNetSalary(basicSalary);
                    Console.WriteLine("Net Salary: " + netSalary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
