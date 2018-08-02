using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    class CanonPrinter : Printer
    {
        public CanonPrinter(string name, string model)
        {
            ValidationInput(name);
            Name = name;
            ValidationInput(model);
            Model = model;
        }
    }
}
