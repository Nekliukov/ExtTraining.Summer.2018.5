using System;
using System.IO;

namespace No8.Solution
{
    public class CanonPrinter
    {
        public CanonPrinter() { }

        public CanonPrinter(PrinterManager printerManager)
        {
            printerManager.OutputTerminator += ShowMessage;
            Name = "Canon";
            Model = "123x";
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