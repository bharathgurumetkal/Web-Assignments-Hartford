using InsuranceLibrary.Models;
using InsuranceLibrary.Services;
namespace InsuranceConsoleApp
{
    internal class Program
    {
        static PolicyService policyService = new PolicyService();
        static void Main(string[] args)
        {

            int choice;
            
            do
            {
                Console.WriteLine("INSURANCE MANAGEMENT SYSTEM");
                Console.WriteLine("1.Add Policy");
                Console.WriteLine("2.View all Policies");
                Console.WriteLine("3.Search Policy by ID");
                Console.WriteLine("4.Update Policy");
                Console.WriteLine("5.Delete Policy");
                Console.WriteLine("0.Exit");

                Console.WriteLine("Enter Choice: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1: AddPolicy();break;
                    case 2: ViewPolicies();break;
                    case 3: SearchPolicy();break;
                    case 4:UpdatePolicy(); break;
                    case 5:DeletePolicy(); break;
                    case 0: Console.WriteLine("Exiting.........");break;
                    default:Console.WriteLine("Invalid Choice!"); break;    
                }

            } while (choice != 0);
        }

        static void AddPolicy()
        {
            Console.WriteLine("Policy Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Policy Holder Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Policy Type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Premium Amount: ");
            decimal premium = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Policy Term(years): ");
            int term = int.Parse(Console.ReadLine());
            InsurancePolicy policy = new InsurancePolicy(id,name,type,premium,term);
            policyService.AddPolicy(policy);
            Console.WriteLine("Policy Added Successfully!");
        }

        static void ViewPolicies()
        {
            var policies = policyService.GetAllPolicies();
            Console.WriteLine("\nID\tName\tType\tPremium\tTerm\tActive");
            foreach(var p in policies)
            {
                Console.WriteLine(p);
            }
        }

        static void SearchPolicy()
        {
            Console.WriteLine("Enter Policy Id: ");
            int id=int.Parse(Console.ReadLine());
            InsurancePolicy policy = policyService.GetPolicyById(id);
            if (policy != null)
            {
                Console.WriteLine(policy);
            }
            else
            {
                Console.WriteLine("Policy not found");
            }
        }

        static void UpdatePolicy()
        {
            Console.WriteLine("Enter Policy Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Premium Amount: ");
            decimal newPremium = decimal.Parse(Console.ReadLine());
            Console.WriteLine("New Term");
            int term=int.Parse(Console.ReadLine());
            bool updated =policyService.UpdatePolicy(id, newPremium, term);
            Console.WriteLine(updated?"Updated successfully":"Policy not found");

        }

        static void DeletePolicy()
        {
            Console.WriteLine("Enter Policy Id: ");
            int id= int.Parse(Console.ReadLine());
            bool deleted = policyService.DeletePolicy(id);
            Console.WriteLine(deleted ? "Deleted successfully" : "Policy not found");
        }
    }
}
