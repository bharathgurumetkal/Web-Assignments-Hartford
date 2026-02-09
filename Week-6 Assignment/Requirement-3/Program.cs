namespace Requirement_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Registration no. to be validated: ");
            string registrationNo = Console.ReadLine();

            bool isValid = ValidateRegistrationNo(registrationNo);

            if (isValid)
            {
                Console.WriteLine("Registration No. is valid");
            }
            else
            {
                Console.WriteLine("Registration No. is invalid");

            }

            static bool ValidateRegistrationNo(string registrationNo)
            {
                string pattern = @"^[A-Z]{2}\s\d{1,2}\s[A-Z]{0,2}\s\d{1,4}$";
;
                return System.Text.RegularExpressions.Regex.IsMatch(registrationNo, pattern);

            }
        }
    }
}
