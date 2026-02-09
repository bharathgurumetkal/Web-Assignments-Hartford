namespace Requirement_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Vehicle 1 details: ");
            string input1= Console.ReadLine();
            Console.WriteLine("Enter Vehicle 2 details: ");
            string input2= Console.ReadLine();

            Vehicle vehicle1 = CreateVehicle(input1);
            Vehicle vehicle2 = CreateVehicle(input2);

            Console.WriteLine("Vehicle 1");
            Console.WriteLine(vehicle1);
            Console.WriteLine();

            Console.WriteLine("Vehicle 2");
            Console.WriteLine(vehicle2);
            Console.WriteLine();

            if(vehicle1.Equals(vehicle2))
            {
                Console.WriteLine("Vehicle 1 is same as Vehicle 2");
            }
            else
            {
                Console.WriteLine("Vehicle 1 and Vehicle 2 are different");
            }
        }

        static Vehicle CreateVehicle(string input)
        {
            string[] details = input.Split(',');
            string registrationNo = details[0];
            string name = details[1];
            string type = details[2];
            double weight = double.Parse(details[3]);
            string ticketNo = details[4];
            DateTime parkedTime = DateTime.Parse(details[5]);
            double cost = double.Parse(details[6]);
            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);
            Vehicle vehicle = new Vehicle(registrationNo, name, type, weight, ticket);
            return vehicle;
        }
    }
}
