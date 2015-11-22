using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzbuzzLibrary
{
    /// <summary>
    /// A Fizzbuzz parsing library
    /// </summary>
    public class Fizzbuzz
    {
        private readonly IWritter _writter;
        private readonly IEnumerable<Rule> _rules;

        /// <summary>
        /// Construts a Fizzbuzz instance
        /// </summary>
        /// <param name="writter">Output writter to use</param>
        /// <param name="rules">Rules to apply to the game</param>
        public Fizzbuzz(IWritter writter, params KeyValuePair<int, string>[] rules )
        {
            this._rules = rules.Select(r => new Rule(r.Key, r.Value));
            this._writter = writter;
        }

        /// <summary>
        /// Parse an input integer
        /// </summary>
        /// <param name="n">the integer to be parsed</param>
        /// <returns>a parsed string </returns>
        public string Parse(int n)
        {
            var result =  this._rules.Aggregate(new StringBuilder(), (stringBuilder, rule) => stringBuilder.Append(rule.Apply(n)));

            if (result.Length == 0)
            {
                result.Append(n.ToString());
            }

            return result.ToString();
        }

        /// <summary>
        /// Run Fizzbuzz to array of integers
        /// </summary>
        /// <param name="lowerbound"></param>
        /// <param name="upperbound"></param>
        public void Run(int lowerbound, int upperbound)
        {
            if (lowerbound > upperbound)
            {
                throw new ArgumentException();
            }

            Enumerable.Range(lowerbound, (upperbound - lowerbound + 1))
                .Select(this.Parse)
                .ToList()
                .ForEach(this.Output);
        }

        private void Output(string str)
        {
            this._writter.WriteLine(str);
        }

        /// <summary>
        /// Rule for  parsing 
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

            /// <summary>
            /// apply rule to the input number
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public string Apply(int n)
            {
                return (n != 0 && n % _key ==0) ? _value : string.Empty;
            }
        }
    }
}
