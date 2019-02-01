using System;
using System.Collections.Generic;
using System.IO;

namespace PharmacyCounting
{
    class RecordReader
    {
        private string headerText = "id,prescriber_last_name,prescriber_first_name,drug_name,drug_cost";
        string filePath;
        StreamReader reader;
        long currentLineNumber = 0;

        public RecordReader(string inputFilePath)
        {
            if (inputFilePath == null)
                Console.WriteLine("inputFilePath is null");
            // throw new System.ArgumentNullException("inputFilePath is null");

            if (inputFilePath.Length < 1)
                Console.WriteLine("Empty inputFilePath");
                // throw new System.ArgumentException("Empty inputFilePath");

            if (!File.Exists(inputFilePath))
                Console.WriteLine("inputFIlePath does not exist");
                // throw new System.ArgumentException("inputFIlePath does not exist");

            this.filePath = inputFilePath;

            try
            {
                this.reader = File.OpenText(this.filePath);

                //read the header line and verify its integrity
                //this way to some extent we can veriy that file encoding is
                //as expected
                ReadHeaderLine();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private void ReadHeaderLine()
        {
            string headerLine = this.reader.ReadLine();
            if(!String.Equals(headerLine, this.headerText)){
                Console.WriteLine("Header Line in the input file is not in expected format");
                // throw new System.ArgumentException("Invalid Header Line in the input file");
            }
            currentLineNumber++;
        }

        public SaleRecord GetNextRecord()
        {
            string record = this.reader.ReadLine();
            
            if (record == null) return null;

            currentLineNumber++;
            string[] values = record.Split(',');
            if (values.Length != 5)
            {
                // throw new System.DataMisalignedException(
                // "Invalid data in inputfile at line number: " + currentLineNumber + 1);
                Console.WriteLine("Invalid data in inputfile at line number: " + currentLineNumber + 1);
                Console.WriteLine("Data: " + record);
                Console.WriteLine("Ignoring the above record.");
                return null;
            }
            return new SaleRecord(values[0], values[1],
                                values[2], values[3], Convert.ToDecimal(values[4]));
        }

        public bool HasNextRecord() {
            if (this.reader.EndOfStream) return false;
            else return true;
        }
        public void close()
        {
            this.reader.Close();
        }
    }

}