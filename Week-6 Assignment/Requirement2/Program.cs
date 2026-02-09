namespace Requirement2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the Parking Lot:");
            string name = Console.ReadLine();

            ParkingLot parkingLot = new ParkingLot(name, null);

            int choice;

            do
            {
                Console.WriteLine("1.Add Vehicle");
                Console.WriteLine("2.Delete Vehicle");
                Console.WriteLine("3.Display Vehicles");
                Console.WriteLine("4.Exit");

                Console.WriteLine("Enter your choice:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        string detail = Console.ReadLine();
                        Vehicle v = Vehicle.CreateVehicle(detail);
                        parkingLot.AddVehicleToParkingLot(v);
                        Console.WriteLine("Vehicle successfully added");
                        break;

                    case 2:
                        Console.WriteLine(
                            "Enter the registration number of the vehicle to be deleted:");
                        string regNo = Console.ReadLine();

                        bool deleted =
                            parkingLot.RemoveVehicleFromParkingLot(regNo);

                        if (deleted)
                            Console.WriteLine("Vehicle successfully deleted");
                        else
                            Console.WriteLine("Vehicle not found in parkinglot");
                        break;

                    case 3:
                        parkingLot.DisplayVehicles();
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            } while (choice != 4);

        }
    }
}
