using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using No8.Solution.Printers;

namespace No8.Solution
{
    public class PrinterManager
    {
        public PrinterManager()
        {
            printers = new List<Printer>();
        }

        private List<Printer> printers { get; set; }

        public void Add(Printer newPrinter)
        {
            CheckNull(newPrinter);
            CheckExistion(newPrinter);          
            printers.Add(newPrinter);
            Console.WriteLine("Printer added");
        }

        public void Print(Printer p1)
        {
            Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            p1.Print(f);
            Log("Print finished");
        }

        public void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        #region Private methods

        private void CheckNull(Printer value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void CheckExistion(Printer value)
        {
            if (printers.Contains(value))
            {
                throw new ArgumentException("Printer is already exists");
            }
        }

        #endregion
    }
}
