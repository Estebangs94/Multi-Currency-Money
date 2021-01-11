using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Bank
    {
        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(to);
        }
    }
}
