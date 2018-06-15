using System;
using System.Diagnostics;

using Compiler.Driver;

namespace Compiler
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Start();

                Options options = new Options(args);
                new Program().Run(options);

                stoper.Stop();

                Console.WriteLine("Compilation succeeded");
                Console.WriteLine("Total time: " + stoper.Elapsed);
            }
            catch (ErrorException e)
            {
                Console.WriteLine("Compilation failed");
                Console.WriteLine("{0}: {1}", e.Location, e.Message);
            }
        }
    }
}
