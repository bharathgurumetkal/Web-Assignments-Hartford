namespace Question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n1=Console.ReadLine();
            string n2= Console.ReadLine();
            bool res1 = int.TryParse(n1, out int num1);
            bool res2 = int.TryParse(n2, out int num2);
            if (res1 && res2)
            {
                Console.WriteLine("Sum: " + (num1 + num2));
            }
            else
            {
                Console.WriteLine("Invalid input ");
            }
        }
    }
}
