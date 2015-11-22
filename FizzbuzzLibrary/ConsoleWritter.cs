using System;

namespace FizzbuzzLibrary
{
    public class ConsoleWritter : IWritter
    {
        public void WriteLine(string r)
        {
            Console.WriteLine(r);
        }
    }
}