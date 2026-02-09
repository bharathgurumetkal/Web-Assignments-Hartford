using Requirement_5;
using System.Collections.Generic;

namespace Requirement_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vehicles:");
            int n = int.Parse(Console.ReadLine());

            List<Vehicle> vehicleList = new List<Vehicle>();

            for (int i = 0; i < n; i++)
            {
                string detail = Console.ReadLine();
                vehicleList.Add(Vehicle.CreateVehicle(detail));
            }

            Console.WriteLine("Enter a type to a sort:");
            Console.WriteLine("1.Sort by weight");
            Console.WriteLine("2.Sort by parked time");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                vehicleList.Sort();
            }
            else if (choice == 2)
            {
                vehicleList.Sort(new ParkedTimeComparer());
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                            "Registration No", "Name", "Type", "Weight", "Ticket No");

            foreach (Vehicle v in vehicleList)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
                    v.RegistrationNo,
                    v.Name,
                    v.Type,
                    v.Weight,
                    v.Ticket.TicketNo);
            }

        }
    }
}