using System.Collections.Generic;

namespace No8.Solution.Console
{
    internal static class MenuHandler
    {
        internal const int ASCI_CODE_0_DIGIT = 48;

        // Для смещения относительно первого пункта меню (т.к в словаре индексы с 0)
        internal const int MENU_ITEMS_SHIFT = 2;

        internal static Dictionary<int, Printer> mapPrinters;


        internal static void GenerateMap(PrinterManager printerManager)
        {
            for (int i = mapPrinters.Count; i < printerManager.Printers.Count; i++)
            {
                mapPrinters.Add(i, printerManager.Printers[i]);
            }
        }

        internal static void CreateNewPrinter(PrinterManager printerManager)
        {
            System.Console.Write("Printer name: ");
            string newName = System.Console.ReadLine();
            System.Console.Write("Model: ");
            string newModel = System.Console.ReadLine();
            printerManager.Add(new Printer(newName, newModel));
        }

        internal static void PrintMenu(PrinterManager printerManager)
        {
            System.Console.WriteLine("Select your choice:");
            System.Console.WriteLine("1: Add new printer");
            for (int i = 0; i < mapPrinters.Count; i++)
            {
                System.Console.WriteLine($"{i + 2}: Print on" +
                                         $" {mapPrinters[i].Name} {mapPrinters[i].Model}");
            }

            System.Console.WriteLine("Press backspace to exit");
        }
    }
}
