using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Dollar
    {
        public Dollar(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; set; }

        public void Times(int multiplier)
        {
            Amount *=  multiplier;
        }
    }
}
