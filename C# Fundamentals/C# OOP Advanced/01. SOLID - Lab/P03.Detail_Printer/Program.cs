using System.Collections.Generic;

namespace P03.Detail_Printer
{
    class Program
    {
        static void Main()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee("pesho"));
            list.Add(new Manager("gosho", new List<string>() { "doc1", "doc2" } ));


            DetailsPrinter detailsPrinter = new DetailsPrinter(list);
            detailsPrinter.PrintDetails();
        }
    }
}
