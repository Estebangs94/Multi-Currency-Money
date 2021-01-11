using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Sum : Expression
    {
        public Sum(Money augend, Money addend)
        {
            Addend = addend;
            Augend = augend;
        }

        public Money Reduce(string to)
        {
            int amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }

        public Money Augend { get; set; }
        public Money Addend { get; set; }
    }
}
