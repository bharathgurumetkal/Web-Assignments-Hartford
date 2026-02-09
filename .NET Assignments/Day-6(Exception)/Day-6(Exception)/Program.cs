namespace Day_6_Exception_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customer c = new customer("Rahul", 2453, 500);
            try
            {
                c.withdraw(450);
            }
            catch (bankexception e)
            {
                Console.WriteLine("Transaction Failed ");
                e.inform();
            }
        }
    }
}
