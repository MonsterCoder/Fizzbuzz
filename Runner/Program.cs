using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzbuzzLibrary;

namespace Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var app = new FizzbuzzLibrary.Fizzbuzz(new AppWriter());

            app.Run(Enumerable.Range(1,100).ToArray());
            Console.Read();
        }
    }
}
