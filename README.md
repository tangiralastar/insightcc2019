# Phatmacy Counting
# Insight Data Engineering Coding Challenge 2019

### Index
- [About](#about)
- [How to execute the program](#how-to-execute-the-program)
  - [Pre-requisites](#pre-requisites)
  - [Windows](#windows)
  - [Linux](#linux)
- [Design/ Code overview](#design-code-overview)
- [Assumptions](#assumptions)
  - [Total Cost in the output file](#total-cost-in-the-output-file)
  - [Ignoring invalid records](#ignoring-invalid-records)
  - [Sorting by drug name](#sorting-by-drug-name)
- [Optimizations that I implemented](#optimizations-that-i-implemented)
- [Optimizations that needs to be implemented](#)
- [Drawbacks of the design](#)
- [Testing](#)

---
### About
This repoaitory contains the solution for the coding challenge that was presented to me when I applied for Insight Data Engineering fellowship and course.

More detail about the challenge can be viewed at https://github.com/InsightDataScience/pharmacy_counting

---
### How to execute the program

Below are the steps to execute the program in diffrent platforms. 

#### Pre-requisites
This solution was developed using .Net Core and writting using C# language. Hence to compile and execute the project we needs .Net Core to be available. Though .Net Core also works on Linux, I haven't tested the project yet in the Linux platform. (to be done)

#### Windows
- **Compilation**
  - Open a command prompt
  - Change direcory to the `src` folder
  - Run the command `dotnet build`
  - This should build the project. Make sure you have write permission in the `src` folder. Since build command will create `bin` and `obj` folders within the `src` folder
- **Execute**
  - use the command `dotnet run <Input File Path> <Output File Path>`
  
In the above command replace <Input File Path> with the fully qalified file location path, where the input file is located.      Example: `Replace <Input File Path> with C:\Users\Radha\Downloads\de_cc_data.txt`
  
In the above command replace <Output File Path> with the fully qalified file location path, where the output file is should be written. Make sure appropriate file permission are avaiable within the output directory to create the output file 
Example: `Replace <Output File Path> with C:\Users\Radha\Desktop\top_cost_drug.txt`

#### Linux
TO BE DONE SOON

---
### Design/ Code overview
The project is design is simple and only consists of 5 classes, which are briefly mentioned below.

**Program.cs**
  This class acts as the driver. The `Main` method is the entry point of code execution. This calls various classes to help in executing the program. At a higher level, below is what this `Main` method does

- Basic input validation for input arguments for the program. Check whether mandatory inputs are passed to the program
- Created a InputReader to read the input file
- Read each line from input file
  - Create a SaleRecord Object
  - Insert the SaleRecord Object into the Sales Object
  - Call `GetSortedSales` method to sort the sales data by total sales of a drug in descending order and when there is a tie, sort by drug name
- Write each record to output file

**RecordReader.cs**
  This class is reponsible for reading each line (record) from the given input file. The important points to be noted are 
- *Ignores any invalid record*
- Reads only one line at a time
- `HasNextRecord` method helps to check if there is any other record left out to be read
 
**RecordWriter.cs**
  This class is reponsible for writing each line (record) into the given output file. The important points to be noted are 
- *Deletes the output file, if it already exists*
- Flushes the output after each record is written in the

**SalesRecord.cs**
  This class is simple class which te represent each input record as a SaleRecord Object.
  
**RecordWriter.cs**
  This class is reponsible for writing each line (record) into the given output file. The important points to be noted are 
- *Deletes the output file, if it already exists*
- Flushes the output after each record is written in the

**Sales.cs**
This class represents the total sales information. 
- Uses HashMap(Dictonary <drugName, DrugSale>)
  - To group the mutiple records of the same drug as one object, *DrugSale* object
  - DrugSale object stores the total cost of each drug sold
  - DrugaSale object, internally uses HashSet to check repition of prescribers to the same drug
  - HashSet is used to efficiently check if a prescriber for a particular drug has been encountered earlier
  - DrugSale object also keeps track of total uniquue prescribers to a particular drug (with the help of HashSet)
- Uses [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) inuilt linary for [SQL like quering on Objects](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects) to sort the values in the HashMap
  - Sort in descending order of total drug sales of a particular drug
  - If there is a tie, in total sales for multiple rug, sort by natural ordering (ascending) of the drug names
  
 ---
### Assumptions
 
#### Total Cost in the output file
- Even if the cost of each drug is in decimal (non integer) format in the input file, I ignore the digits after the decimal point in the output file.
- Input file can contain the drug sale cost in decimal format
- For the puprpose of sorting drugs by total sale cost, I still leverage the decimal format

#### Ignoring invalid records
- I ignore the records in the input file, which do not strictly adhere to the input format. Some examples of invalid records are mentioned below
  - `1447335856,"ADAMS, JR.",WILLIE,AZITHROMYCIN,97.41`
Note the comma, which is used as seperator in the input record is within the double quotes, which causes trouble in basic parsing of the input record.

#### Sorting by drug name
I use inbuilt sorting of strings provided by language framework.

---
### Optimizations that I implemented

---
### Optimizations that needs to be implemented

---
### Drawbacks of the design

---
### Testing
