using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class Loger: ILogger
    {
        public void Log(string value)
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.Write(value);
            }
        }
    }
}
