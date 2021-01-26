using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Bank
    {
        private readonly Dictionary<Pair, int> rates;

        public Bank()
        {
            rates = new Dictionary<Pair, int>();
        }

        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to)) return 1;

            int rate;
            rates.TryGetValue(new Pair(from, to), out rate);
            return rate;
        }
    }
}
