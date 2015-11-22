using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzbuzzLibrary;

namespace Fizzbuzz.Runner.Console
{
    //console Fizzbuzz runner
    internal class Program
    {
        static void Main(string[] args)
        {
           var app = new FizzbuzzLibrary.Fizzbuzz(new ConsoleWritter());

            app.Run(Enumerable.Range(1,100).ToArray());
            System.Console.Read();
        }
    }
}
