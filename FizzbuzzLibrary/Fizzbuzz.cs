using System;
using System.Collections.Generic;
using System.Text;

namespace FizzbuzzLibrary
{
    /// <summary>
    /// A Fizzbuzz parsing library
    /// </summary>
    public class Fizzbuzz
    {
        private readonly IWritter _writter;

        /// <summary>
        /// Construts a Fizzbuzz instance
        /// </summary>
        /// <param name="writter">Output writter to use</param>
        public Fizzbuzz(IWritter writter)
        {
            _writter = writter;
        }

        /// <summary>
        /// Parse an input integer
        /// </summary>
        /// <param name="n">the integer to be parsed</param>
        /// <returns>a parsed string </returns>
        public string Parse(int n)
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


        /// <summary>
        /// Run Fizzbuzz to array of integers
        /// </summary>
        /// <param name="numbers"></param>
        public void Run(params int[] numbers)
        {
           new List<int>(numbers).ForEach( n =>  this._writter.WriteLine(this.Parse(n)));
        }

        /// <summary>
        /// Rule of  parsing 
        /// </summary>
        public class Rule
        {
            private readonly int _key;
            private readonly string _value;

            public Rule(int key, string value)
            {
                if (key == 0)
                {
                    throw new ArgumentException();
                }
                _key = key;
                _value = value;
            }

            public string Apply(int n)
            {
                return (n != 0 && n % _key ==0) ? _value : string.Empty;
            }
        }
    }
}
