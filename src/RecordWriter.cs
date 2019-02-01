using System;
using System.Collections.Generic;
using System.IO;

namespace PharmacyCounting
{

    class RecordWriter
    {
        private string headerText = "drug_name,num_prescriber,total_cost";

        string writePath = String.Empty;

        StreamWriter writer;

        public RecordWriter(string outputFilepath)
        {
            this.writePath = outputFilepath;
            try
            {
                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }
                writer = new StreamWriter(this.writePath);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        /* This function writes header in the output file */
        public void WriteHeaderLine()
        {
            try
            {
                if (writer != null )
                {
                    writer.WriteLine(headerText);
                    writer.Flush();
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        /*   */
        public void WriteOutputText(string drug_name, Int32 num_prescriber,decimal total_cost)
        {
            try
            {
                if(writer!=null)
                {
                    writer.WriteLine(String.Format("{0},{1},{2}", 
                            drug_name, num_prescriber, Decimal.Truncate(total_cost)));
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public void close()
        {
            writer.Flush();
            writer.Close();
        }
    }
}