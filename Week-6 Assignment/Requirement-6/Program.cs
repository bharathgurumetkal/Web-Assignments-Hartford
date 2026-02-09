namespace Requirement_6
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

            SortedDictionary<string, int> res = Vehicle.TypeWiseCount(vehicleList);

            Console.WriteLine("{0,-15} {1}","Type","No. of Vehicles");

            foreach(var item in res)
            {
                Console.WriteLine("{0,-15} {1}",item.Key,item.Value);
            }
        }
    }
}
