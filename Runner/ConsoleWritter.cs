using System;
using FizzbuzzLibrary;

namespace Fizzbuzz.Runner.Console
{
    /// <summary>
    /// Console implementation of IWritter
    /// </summary>
    public class ConsoleWritter : IWritter
    {
        public void WriteLine(string r)
        {
            System.Console.WriteLine(r);
        }
    }
}