using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Domain
{
    public class DollarTests
    {
        [Fact]
        public void TestMultiplication()
        {
            var dollar = Money.Dollar(5);

            Assert.Equal(Money.Dollar(10).Amount, dollar.Times(2).Amount);
            Assert.Equal(Money.Dollar(15).Amount, dollar.Times(3).Amount);
        }

        [Fact]
        public void TestEquality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.True(Money.Franc(5).Equals(Money.Franc(5)));
            Assert.False(Money.Franc(5).Equals(Money.Franc(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }


        [Fact]
        public void TestCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency());
            Assert.Equal("CHF", Money.Franc(1).Currency());
        }

        [Fact]
        public void TestAmount()
        {
            Assert.Equal(5, Money.Franc(5).Amount);
            Assert.Equal(21, Money.Dollar(21).Amount);
        }

        [Fact]
        public void TestSimpleAddition()
        {
            Expression sum = Money.Dollar(5).Plus(Money.Dollar(5));
            Bank bank = new Bank();
            Money reduced = Bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(10).Amount, reduced.Amount);
        }

    }
}
