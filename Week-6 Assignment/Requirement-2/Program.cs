namespace Requirement_2
{
    public class Program
    {
        
        static ParkingLot parkingLot = new ParkingLot();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                Console.WriteLine("3. Display Vehicles");
                Console.WriteLine("0. Exit");

                Console.Write("Enter choice: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        RemoveVehicle();
                        break;
                    case 3:
                        DisplayVehicles();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }

        static void AddVehicle()
        {
            try
            {
                Console.WriteLine("Enter vehicle details:");
                string input = Console.ReadLine();

                Vehicle vehicle = CreateVehicle(input);
                parkingLot.AddVehicle(vehicle);

                Console.WriteLine("Vehicle added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RemoveVehicle()
        {
            Console.Write("Enter Registration No: ");
            string regNo = Console.ReadLine();

            bool removed = parkingLot.RemoveVehicle(regNo);

            if (removed)
                Console.WriteLine("Vehicle removed successfully");
            else
                Console.WriteLine("Vehicle not found");
        }

        static void DisplayVehicles()
        {
            var vehicles = parkingLot.GetAllVehicles();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles parked");
                return;
            }

            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine(v);
                Console.WriteLine();
            }
        }

        static Vehicle CreateVehicle(string input)
        {
            string[] data = input.Split(',');

            string registrationNo = data[0];
            string name = data[1];
            string type = data[2];
            double weight = double.Parse(data[3]);

            string ticketNo = data[4];
            DateTime parkedTime =
                DateTime.ParseExact(data[5], "dd-MM-yyyy HH:mm:ss", null);
            double cost = double.Parse(data[6]);

            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

            return new Vehicle(registrationNo, name, type, weight, ticket);
        }
    }
}
