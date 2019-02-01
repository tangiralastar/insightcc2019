# Phatmacy Counting
# Insight Data Engineering Coding Challenge 2019

### Index
- [About](#about)
- [How to execute the program](#how-to-execute-the-program)
  - Pre-requisites
  - Windows
  - Linux
- Design/ Code overview
- Assumptions
  - Total Cost in the output file
  - Ignoring invalid records
  - Sorting by drug name
- Optimizations that I implemented
- Optimizations that needs to be implemented
- Drawbacks of the design
- Testing

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
- ##### Compilation
- Open a command prompt
- Change direcory to the `src` folder
- Run the command `dotnet build`
- This should build the project. Make sure you have write permission in the `src` folder. Since build command will create `bin` and `obj` folders within the `src` folder
- ##### Execute
- use the command `dotnet run <Input File Path> <Output File Path>`
In the above command replace <Input File Path> with the fully qalified file location path, where the input file is located. 
     Example: `Replace <Input File Path> with C:\Users\Radha\Downloads\de_cc_data.txt`
In the above command replace <Output File Path> with the fully qalified file location path, where the output file is should be writte. Make sure appropriate file permission are avaiable within the output directory to create the output file 
     Example: `Replace <Output File Path> with C:\Users\Radha\Desktop\top_cost_drug.txt`


---
