using System;
using System.Collections.Generic;

namespace No8.Solution.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PrinterManager pm = new PrinterManager();

            // Заранее созданные объекты, которые раньше инициализировались
            // с собственными типами Canon и Epson
            Printer canon = new Printer("Canon", "X321");
            Printer epson = new Printer("Epson", "ZOOM");
            pm.Add(canon); pm.Add(epson);
            MenuHandler.mapPrinters = new Dictionary<int, Printer>();
            MenuHandler.mapPrinters.Add(0, canon);
            MenuHandler.mapPrinters.Add(1, epson);

            ConsoleKeyInfo key = default(ConsoleKeyInfo);
            while (key.Key != ConsoleKey.Backspace)
            {
                MenuHandler.GenerateMap(pm);
                MenuHandler.PrintMenu(pm);
                key = System.Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    System.Console.WriteLine();
                    MenuHandler.CreateNewPrinter(pm);
                }
                else
                {
                    pm.Print(MenuHandler.mapPrinters[
                        key.KeyChar - MenuHandler.ASCI_CODE_0_DIGIT - MenuHandler.MENU_ITEMS_SHIFT
                    ]);
                }               
            }           
        }
    }
}
