using System;
using System.Collections.Generic;
using static PharmacyCounting.Sales;

namespace PharmacyCounting
{
    class Program
    {
        static void Main(string[] args)
        {

            if(null == args || args.Length < 2) {
                throw new System.ArgumentNullException("Arguments inputFilePath and outputFilePath are mandatory");
            }
            string inputFilePath = args[0];
            string outputFilePath = args[1];

            if(System.String.IsNullOrWhiteSpace(inputFilePath)){
                Console.WriteLine("Invalid Input File Path: " + inputFilePath);
                // throw new System.ArgumentNullException("Invalid Input File Path: " + inputFilePath);
            }

            SaleRecord saleRecord = null;
            Sales sales = new Sales();
            //create a input file reader
            RecordReader recordReader = new RecordReader(inputFilePath);
            //read all sale proceeds
            while( recordReader.HasNextRecord()) 
            {
                saleRecord = recordReader.GetNextRecord();
                if(saleRecord != null) {
                    sales.AddSale(saleRecord);
                }
            }
            
            IList<DrugSale> list = sales.GetSortedSales();
            RecordWriter recordWriter = new RecordWriter(outputFilePath);
            recordWriter.WriteHeaderLine();
            foreach(DrugSale drug in list) {
                // Console.WriteLine(String.Format("{0},{1},{2}", 
                //                     drug.drug_name, drug.num_prescriber, drug.total_cost));
                recordWriter.WriteOutputText(drug.drug_name, drug.num_prescriber, drug.total_cost);

            }
            recordWriter.close();

        }
    }
}
