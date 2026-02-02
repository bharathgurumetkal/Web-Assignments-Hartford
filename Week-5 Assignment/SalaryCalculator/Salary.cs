namespace SalaryCalculator
{

        public class Salary
        {
            public static double CalculateNetSalary(double basicSalary)
            {
          

                double hra = basicSalary * 0.20;
                double da = basicSalary * 0.10;
                double pf = 0;

                if (basicSalary >= 15000)
                    pf = basicSalary * 0.12;

                double netSalary = basicSalary + hra + da - pf;
                return netSalary;
            }
        }



}
