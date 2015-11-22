using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzbuzzLibrary
{
    public class Fizzbuzz
    {
        private readonly IWriter _writer;

        public Fizzbuzz(IWriter writer)
        {
            _writer = writer;
        }

        public string Trans(int n)
        {
            var sb = new StringBuilder();
            if (n%3 == 0)
            {
                sb.Append( "Fizz");
            }

            if (n%5 == 0)
            {
                sb.Append("Buzz");
            }

            if (sb.Length == 0)
            {
                sb.Append(n.ToString());
            }
            return sb.ToString();

        }

        public void Run(params int[] numbers)
        {
           new List<int>(numbers).ForEach( n =>  this._writer.WriteLine(this.Trans(n)));
        }
    }

    public interface IWriter
    {
        void WriteLine(string r);
    }

    public class AppWriter : IWriter
    {
        public void WriteLine(string r)
        {
            Console.WriteLine(r);
        }
    }
}
