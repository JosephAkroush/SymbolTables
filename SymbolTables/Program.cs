using System;
using SymbolTables.SequentialSearch;

namespace SymbolTables
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequentialSearchSymbolTable = new LinkedListSymbolTable<String, Double>();
            sequentialSearchSymbolTable.Put("A+", 4.33);
            sequentialSearchSymbolTable.Put("A", 4.00);
            sequentialSearchSymbolTable.Put("A-", 3.67);
            sequentialSearchSymbolTable.Put("B+", 3.33);
            sequentialSearchSymbolTable.Put("B", 3.00);
            sequentialSearchSymbolTable.Put("B-", 2.67);
            sequentialSearchSymbolTable.Put("C+", 2.33);
            sequentialSearchSymbolTable.Put("C", 2.00);
            sequentialSearchSymbolTable.Put("C-", 1.67);
            sequentialSearchSymbolTable.Put("D", 1.00);
            sequentialSearchSymbolTable.Put("F", 0.00);

            String input = String.Empty;
            int gradeCount = 0;
            double scoreTotal = 0.0;

            while (input != "x")
            {
                Console.Write("Enter a letter grade or 'x' to exit: ");
                input = Console.ReadLine();

                if (input.Equals("x", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }

                scoreTotal += sequentialSearchSymbolTable.Get(input);
                gradeCount++;
            }

            Console.WriteLine($"The average score is {String.Format("{0:f2}", scoreTotal / gradeCount)}.");
        }
    }
}