namespace Day_1_Assignment
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //Hello world program
            Console.WriteLine("Hello, World!");
            Console.WriteLine("I am Bharath");


            //Arithmetic operations
            Console.Write("Enter a number: ");
         
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter another number: ");
          
            int num2 = Convert.ToInt32(Console.ReadLine());

       
            Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);

        
            Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);

           
            Console.WriteLine("{0} x {1} = {2}", num1, num2, num1 * num2);

           
            Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);

            Console.WriteLine("{0} mod {1} = {2}", num1, num2, num1 % num2);

            int number1, number2, temp;

          
            //swapping of two numbers
            Console.Write("\nInput the First Number : ");
      
            number1 = int.Parse(Console.ReadLine());

           
            Console.Write("\nInput the Second Number : ");
      
            number2 = int.Parse(Console.ReadLine());

           
            temp = number1;
            number1 = number2;
            number2 = temp;

            
            Console.Write("\nAfter Swapping : ");
            Console.Write("\nFirst Number : " + number1);
            Console.Write("\nSecond Number : " + number2);

            //check if x==20 or y==20 or (x+y==20)
            int x, y; 
            int result;

            Console.WriteLine("\nInput an integer:"); 
            x = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Input another integer:");
            y = Convert.ToInt32(Console.ReadLine()); 

     
            Console.WriteLine(x == 20 || y == 20 || (x + y == 20));

            //sum of digits of a number

            Console.Write("Input a number(integer): "); 
            int n = Convert.ToInt32(Console.ReadLine()); 

            int sum = 0;

          
            while (n != 0)
            {
                sum += n % 10; 
                n /= 10; 
            }

          
            Console.WriteLine("Sum of the digits of the said integer: " + sum);

            //conversion to kelvin and fahrenheit

            Console.Write("Enter the amount of Celsius: "); 
            int celsius = Convert.ToInt32(Console.ReadLine()); 

         
            Console.WriteLine("Kelvin = {0}", celsius + 273);

        
            Console.WriteLine("Fahrenheit = {0}", celsius * 18 / 10 + 32);

            string line = "Write a C# Sharp Program to display the following pattern using the alphabet.";

          
            Console.WriteLine(line.ToLower());

            //Multiplication Table
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nMultiplication Table of {number}:");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
            }


            //Check if an integer is in the range -10 to 10
            Console.Write("Input a first number: ");

            int m = Convert.ToInt32(Console.ReadLine());

          
            Console.Write("Input a second number: ");

         
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(((m >= -10 && m <= 10)) || ((n2 >= -10 && n2 <= 10)));
        }
    }

}
