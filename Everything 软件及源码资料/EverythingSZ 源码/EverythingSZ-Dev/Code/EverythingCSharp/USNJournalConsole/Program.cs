using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using QueryEngine;
using System.Diagnostics;

namespace USNJournalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            var allFiles = Engine.GetAllFilesAndDirectories();

            watch.Stop();

            Console.WriteLine("{0} files, {1} seconds", allFiles.Count(), watch.Elapsed.TotalSeconds);

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
