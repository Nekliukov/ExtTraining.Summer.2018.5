using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace No8.Solution
{
    public class PrinterManager
    {
        public event EventHandler<TerminatorEventArgs> OutputTerminator = delegate { };

        public void SimulateStartOutput(string message)
            => OnOutputTerminator(new TerminatorEventArgs(message));

        public void SimulateStopOutput(string message)
            => OnOutputTerminator(new TerminatorEventArgs(message));

        public PrinterManager() => Printers = new List<object>();

        public List<object> Printers { get; set; }

        public void Add(Printer p1)
        {
            Console.WriteLine("Enter printer name");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            p1.Model = Console.ReadLine();

            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                Console.WriteLine("Printer added");
            }
        }

        public void Print(Printer printer)
        {
            printer.Register(this);
            var fileToWrite= new OpenFileDialog();
            fileToWrite.ShowDialog();
            using (var file = File.OpenRead(fileToWrite.FileName))
            {
                SimulateStartOutput($"\nStart outputting {fileToWrite.FileName} content");
                printer.Print(file);
                SimulateStartOutput($"Stop outputting {fileToWrite.FileName} content");
            }           
            
            Log("Print finished");
            printer.Unregister(this);
        }

        public void Log(string value)
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.Write(value);
            }
        }

        protected virtual void OnOutputTerminator(TerminatorEventArgs e)
        {
            EventHandler<TerminatorEventArgs> temp = OutputTerminator;
            temp?.Invoke(this, e);
        }
    }
}