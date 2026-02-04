using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceLibrary.Models;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private List<InsurancePolicy> policies=new List<InsurancePolicy>();

        //Add Policy
        public void AddPolicy(InsurancePolicy policy)
        {
            policies.Add(policy);
        }

        //VIEW ALL
         
        public List<InsurancePolicy> GetAllPolicies()
        {
            return policies;
        }

        //search by id
        public InsurancePolicy GetPolicyById(int id)
        {
            foreach (var p in policies)
            {
                if (p.PolicyId == id) return p;
            }
            return null;
        }

        //update
        public bool UpdatePolicy(int id,decimal newPremium,int newTerm)
        {
            InsurancePolicy policy= GetPolicyById(id);
            if (policy!=null)
            {
                policy.PremiumAmount = newPremium;
                policy.PolicyTerm = newTerm;
                return true;
            }
            return false;
        }

        //delete
        public bool DeletePolicy(int id)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy != null)
            {
                policies.Remove(policy);
                return true;
            }
            return false;
        }

    }
}
