namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age: ");
            string ip = Console.ReadLine();
            bool res = int.TryParse(ip, out int age);
            if (res)
            {
                Console.WriteLine("Valid Age: " + age);
            }
            else
            {
                Console.WriteLine("Invalid input ");
            }
        }
    }
}
