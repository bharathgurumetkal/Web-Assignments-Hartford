using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6_Exception_
{
    public class bankexception:Exception
    {
        int acc;
        int bal;
        public bankexception(int a, int b)
        {
            acc = a;
            bal = b;
        }
        public void inform()
        {
            Console.WriteLine("Account Number: " + acc
            + " Balance left: " + bal);
        }
    }
}
