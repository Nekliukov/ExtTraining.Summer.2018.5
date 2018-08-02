using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    class EpsonPrinter: Printer
    {
        public EpsonPrinter(string name, string model)
        {
            ValidationInput(name);
            Name = name;
            ValidationInput(model);
            Model = model;
        }
    }
}
