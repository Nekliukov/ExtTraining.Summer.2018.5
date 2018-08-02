using System;
using System.IO;

namespace No8.Solution
{
    public class EpsonPrinter
    {
        public EpsonPrinter() { }

        public EpsonPrinter(PrinterManager printerManager)
        {
            printerManager.OutputTerminator += ShowMessage;
            Model = "231";
            Name = "Epson";
        }

        public void Print(FileStream fs)
        {

            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }

        public string Name { get; set; }

        public string Model { get; set; }

        public void Register(PrinterManager manager) => manager.OutputTerminator += ShowMessage;

        public void Unregister(PrinterManager manager) => manager.OutputTerminator -= ShowMessage;

        public void ShowMessage(object sender, TerminatorEventArgs e) => Console.WriteLine(e.Message);
    }
}