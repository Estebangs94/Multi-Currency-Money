using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Pair
    {
        private readonly string from;
        private readonly string to;

        public Pair(string from, string to)
        {
            this.from = from;
            this.to = to;
        }

        public override bool Equals(Object objec)
        {
            Pair pair = (Pair) objec;

            return from.Equals(pair.from) && to.Equals(pair.to);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
