using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TakenApp.Models
{
    public class Logger
    {
        public void WriteToLog(string type, string log)
        {
            int exclamationCount = type.Length + log.Length + 9;
            Debug.WriteLine("[" + new string('!', exclamationCount) + "]");
            Debug.WriteLine(String.Format("[LOGGER; {0}] {1}", type, log));
            Debug.WriteLine("[" + new string('!', exclamationCount) + "]");
        }
    }
}
