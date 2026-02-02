namespace Question6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 6, 2, 1 };
            Console.WriteLine("Array length is : ",a.Length);
            Array.Sort(a);
            Console.WriteLine("Sorted array is :");
            foreach(int x in a) Console.Write(x+" ");
            Array.Reverse(a);
            Console.WriteLine("The reversed array is : ");
            foreach(int e in a) Console.Write(e+" ");
        }
    }
}
