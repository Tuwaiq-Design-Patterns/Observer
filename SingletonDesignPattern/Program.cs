using System;
using System.Collections.Generic;

namespace SingletonDesignPattern
{
    class Program
    {
        class Printer
        {
            private static Printer _instance;
            private List<string> _papers = new List<string>();
            private Printer() { }
            public static Printer GetInstance() => _instance ?? (_instance = new Printer());

            public Printer AddPaper(string paper)
            {
                _papers.Add(paper);
                return this;
            }
            public void PrintPapers()
            {
                foreach (var paper in _papers) Console.WriteLine($"Printing: {paper}");
                _papers.Clear();
                Console.WriteLine("\nAll papers printed successfully\n");
            }
        }
        static void Main(string[] args)
        {
            Printer officePrinter = Printer.GetInstance();

            for (int i = 0; i < 5; i++) officePrinter.AddPaper($"Paper number {i}");

            // to test that the Printer returns only one instance!
            officePrinter = Printer.GetInstance();

            officePrinter.PrintPapers();
        }
    }
}
