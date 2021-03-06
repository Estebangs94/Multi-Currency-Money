﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Money : IExpression
    {
        protected string currency;

        public int Amount { get; set; }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, currency);
        }

        public Money(int amount, string currency)
        {
            Amount = amount;
            this.currency = currency;
        }

        public bool Equals(Money money)
        {
            return money.Amount == Amount
                && money.currency == currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public string Currency()
        {
            return currency;
        }

        public IExpression Plus(Money addend)
        {
            return new Sum(this, addend);
        }

        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(currency, to);

            return new Money(Amount / rate, to);
        }
    }
}
