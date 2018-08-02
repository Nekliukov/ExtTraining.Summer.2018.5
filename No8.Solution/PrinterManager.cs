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

        public void Print(EpsonPrinter p1)
        {
            p1.Register(this);
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            SimulateStartOutput("Start outputing file content");
            p1.Print(f);
            SimulateStopOutput("Stop outputing file content");
            Log("Print finished");
            p1.Unregister(this);
        }

        public void Print(CanonPrinter p1)
        {
            p1.Register(this);
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
            p1.Unregister(this);
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