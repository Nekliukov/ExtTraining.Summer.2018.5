using System;
using System.Runtime.CompilerServices;
using No8.Solution;

namespace No8.Solution.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ConsoleKeyInfo key = default(ConsoleKeyInfo);

            while (key.Key != ConsoleKey.Backspace)
            {
                PrinterManager pm = new PrinterManager();
                Printer canon = new Printer("Canon", "X321");
                Printer epson = new Printer("Epson", "ZOOM");

                System.Console.WriteLine("Select your choice:");
                System.Console.WriteLine("1:Add new printer");
                System.Console.WriteLine("2:Print on Canon");
                System.Console.WriteLine("3:Print on Epson");
                System.Console.WriteLine("Press backspace to exit");

                key = System.Console.ReadKey();
                //if (key.Key == ConsoleKey.D1)
                //{
                //    CreatePrinter();
                //}

                if (key.Key == ConsoleKey.D2)
                {
                    pm.Print(canon);
                }

                if (key.Key == ConsoleKey.D3)
                {
                    pm.Print(epson);
                }
            }
        }
    }
}
