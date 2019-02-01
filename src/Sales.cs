using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyCounting
{
    /**
     * This class represents the total sales information.
     */
    class Sales
    {
        private IDictionary<string, DrugSale> saleDict;

        public Sales()
        {
            this.saleDict = new Dictionary<string, DrugSale>();
        }

        public void AddSale(SaleRecord sale)
        {
            DrugSale drugSale = null;
            if (saleDict.ContainsKey(sale.drugName))
            {
                drugSale = saleDict[sale.drugName];
                drugSale.AddSaleRecord(sale);
            }
            else
            {
                drugSale = new DrugSale(sale.drugName);
                drugSale.AddSaleRecord(sale);
                saleDict.Add(sale.drugName, drugSale);
            }
        }

        public List<DrugSale> GetSortedSales()
        {
            var orderedCollection = saleDict.OrderByDescending(pair => pair.Value.total_cost)
                                    .ThenBy(pair => pair.Value.drug_name);
            return orderedCollection.Select(pair => pair.Value).ToList();
        }

        public class DrugSale
        {
            public string drug_name;
            public decimal total_cost;
            public int num_prescriber;
            public ISet<string> prescribers;

            public DrugSale(string drug_name)
            {
                this.drug_name = drug_name;
                this.total_cost = 0;
                this.num_prescriber = 0;
                this.prescribers = new HashSet<string>();
            }

            internal void AddSaleRecord(SaleRecord sale)
            {
                this.total_cost = this.total_cost + sale.drugCost;
                bool isNewPrescriber = this.prescribers.Add(sale.GetPrescriberFullName());
                if (isNewPrescriber)
                {
                    this.num_prescriber++;
                }
            }
        }
    }
}