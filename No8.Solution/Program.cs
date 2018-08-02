using System;
using No8.Solution.Printers;

namespace No8.Solution
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            while (true)
            {
                CanonPrinter cp = new CanonPrinter("Canon", "911");
                EpsonPrinter ep = new EpsonPrinter("Epson", "355");
                PrinterManager pm = new PrinterManager();
                Console.WriteLine("Select your choice:");
                Console.WriteLine("1:Add new printer");
                Console.WriteLine("2:Print on Canon");
                Console.WriteLine("3:Print on Epson");

                var key = Console.ReadKey();

                //if (key.Key == ConsoleKey.D1)
                //{
                //    Console.WriteLine("Enter printer name");
                //    string name = Console.ReadLine();
                //    Console.WriteLine("Enter printer model");
                //    string model = Console.ReadLine();
                //    PrinterManager.Add(new EpsonPrinter(name, model));
                //}

                if (key.Key == ConsoleKey.D2)
                {
                    pm.Print(cp);
                }

                if (key.Key == ConsoleKey.D3)
                {
                    pm.Print(ep);
                }

                // waiting

            }

            //private static void Print(EpsonPrinter epsonPrinter)
            //{
            //    PrinterManager.Print(epsonPrinter);
            //    PrinterManager.Log("Printed on Epson");
            //}

            //private static void Print(CanonPrinter canonPrinter)
            //{
            //    PrinterManager.Print(canonPrinter);
            //    PrinterManager.Log("Printed on Canon");
            //}

            //private static void CreatePrinter()
            //{
            //    PrinterManager.Add(new Printer());
            //}

        }
    }
}