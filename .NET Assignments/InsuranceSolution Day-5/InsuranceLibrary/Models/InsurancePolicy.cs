namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm { get; set; }
        public bool IsActive { get; set; }

        public InsurancePolicy()
        {

        }
        public InsurancePolicy(int id, string name, string type, decimal amount, int term)
        {
            PolicyId = id;
            PolicyHolderName = name;
            PolicyType = type;
            PremiumAmount = amount;
            PolicyTerm = term;
            IsActive = true;
        }

        override public string ToString()
        {
            return $"PolicyId: {PolicyId}, PolicyHolderName: {PolicyHolderName}, PolicyType: {PolicyType}, PremiumAmount: {PremiumAmount}, PolicyTerm: {PolicyTerm}, IsActive: {IsActive}";
        }




    }
}
