namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter ra xa ya: ");
        double ra = double.Parse(Console.ReadLine());
        double xa = double.Parse(Console.ReadLine());
        double ya = double.Parse(Console.ReadLine());

        Console.Write("Enter rb xb yb: ");
        double rb = double.Parse(Console.ReadLine());
        double xb = double.Parse(Console.ReadLine());
        double yb = double.Parse(Console.ReadLine());

        double distance = Math.Sqrt(
            Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2)
        );

        if (distance + rb < ra)
            Console.WriteLine("B is in A");
        else if (distance + ra < rb)
            Console.WriteLine("A is in B");
        else if (distance < ra + rb)
            Console.WriteLine("A and B intersect");
        else
                Console.WriteLine("A and B do not intersect");
        }
    }
}
