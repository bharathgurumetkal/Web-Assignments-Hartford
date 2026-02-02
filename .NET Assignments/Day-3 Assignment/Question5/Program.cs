namespace Question5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] marks = new int[3][];

            marks[0] = new int[] { 80, 90 };
            marks[1] = new int[] { 70, 75, 85 };
            marks[2] = new int[] { 60 };

            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write("Student " + (i + 1) + ": ");
                foreach (int m in marks[i])
                {
                    Console.Write(m + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
