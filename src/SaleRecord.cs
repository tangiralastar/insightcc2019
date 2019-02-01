using System.Collections.Generic;

namespace PharmacyCounting
{
    class SaleRecord
    {
        public string id = System.String.Empty;
        public string lastName = System.String.Empty;
        public string firstName = System.String.Empty;
        public string drugName = System.String.Empty;
        public decimal drugCost = 0;

        public SaleRecord(string id,
                        string lastName,
                        string firstName,
                        string drugName,
                        decimal cost)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;;
            this.drugName = drugName;
            this.drugCost = cost;
        }

        public string GetPrescriberFullName() {
            return this.firstName + this.lastName;
        }
    }
}