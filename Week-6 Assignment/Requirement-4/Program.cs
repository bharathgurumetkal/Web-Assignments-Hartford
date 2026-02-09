namespace Requirement_4
{
    internal class Program
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

            Console.WriteLine("Enter a search type:");
            Console.WriteLine("1.By type");
            Console.WriteLine("2.By parked time");

            int choice = int.Parse(Console.ReadLine());
            VehicleBO vehicleBO = new VehicleBO();
            List<Vehicle> result = null;

            if (choice == 1)
            {
                Console.WriteLine("Enter the vehicle type");
                string type = Console.ReadLine();
                result = vehicleBO.FindVehicle(vehicleList, type);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the parked time:");
                DateTime parkedTime =
                    DateTime.ParseExact(Console.ReadLine(),
                    "dd-MM-yyyy HH:mm:ss", null);

                result = vehicleBO.FindVehicle(vehicleList, parkedTime);
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return;
            }

            if (result.Count == 0)
            {
                Console.WriteLine("No such vehicle is present");
                return;
            }

            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                "Registration No", "Name", "Type", "Weight", "Ticket No");

            foreach (Vehicle v in result)
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
