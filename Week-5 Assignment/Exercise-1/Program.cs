namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of matches: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int runs = i * (i - 1) * (i + 1);
                Console.Write(runs + " ");
            }
        }
    }
}
