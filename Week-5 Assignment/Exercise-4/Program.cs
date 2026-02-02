using System;

namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Previous Reading: ");
            int prev = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Current Reading: ");
            int curr = Convert.ToInt32(Console.ReadLine());

            int units = curr - prev;
            double amount = 0;

            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 250)
                amount = 100 * 1.5 + (units - 100) * 2.5;
            else if (units <= 550)
                amount = 100 * 1.5 + 150 * 2.5 + (units - 250) * 4.5;
            else
                amount = 100 * 1.5 + 150 * 2.5 + 300 * 4.5 + (units - 550) * 7.5;

            Console.Write("Enter Connection Type: ");
            string type = Console.ReadLine();

            double meterRent = 0;
            if (type == "Industrial") meterRent = 2500;
            else if (type == "Business") meterRent = 1500;
            else if (type == "Domestic") meterRent = 1000;

            double total = amount + meterRent;

            Console.WriteLine("Units Consumed : " + units);
            Console.WriteLine("Bill Amoun :" + total);
     

        }
    }
}
