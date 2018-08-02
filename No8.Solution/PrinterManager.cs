using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace No8.Solution
{
    public class PrinterManager
    {
        // Пока public, потом изменю
        public List<Printer> Printers;

        // Список принтеров не нужен другим типам, да и это нарушит инкапсуляцию

        // Добавленное событие
        public event EventHandler<TerminatorEventArgs> OutputTerminator = delegate { };

        // Методы, транслирующие въодную информацию в желаемое событие
        public void SimulateStartOutput(string message)
            => OnOutputTerminator(new TerminatorEventArgs(message));

        public void SimulateStopOutput(string message)
            => OnOutputTerminator(new TerminatorEventArgs(message));

        // Мы заранее знаем, что работаем с Printer
        public PrinterManager() => Printers = new List<Printer>();

        public void Add(Printer newPrinter)
        {
            if (newPrinter == null)
            {
                throw new ArgumentNullException(nameof(newPrinter));
            }

            foreach (var printer in Printers)
            {
                if (printer.Equals(newPrinter))
                {
                    Console.WriteLine("Error. This printer is already exists");
                    return;
                }
            }

            Printers.Add(newPrinter);
        }

        public void Print(Printer printer)
        {
            printer.Register(this);
            var fileToWrite= new OpenFileDialog();
            fileToWrite.ShowDialog();
            using (var file = File.OpenRead(fileToWrite.FileName))
            {
                SimulateStartOutput($"\n{printer.Name} {printer.Model} starts outputting" +
                                    $" {fileToWrite.SafeFileName} content");
                printer.Print(file);
                SimulateStartOutput($"\n{printer.Name} {printer.Model} has foun end of file");
            }           
            
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