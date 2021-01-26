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
            IExpression sum = Money.Dollar(5).Plus(Money.Dollar(5));
            Bank bank = new Bank();
            Money reduced = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(10).Amount, reduced.Amount);
        }

        [Fact]
        public void TestPlusRetursSum()
        {
            Money five = Money.Dollar(5);
            IExpression result = five.Plus(five);
            Sum sum = (Sum)result;
            Assert.Equal(five, sum.Augend);
            Assert.Equal(five, sum.Addend);
        }

        [Fact]
        public void TestReduceSum()
        {
            //no hay mucho por hacer, Equal no funciona igual que en JUnit, chequeamos contra properties
            IExpression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            Bank bank = new Bank();
            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(7).Amount, result.Amount);
            Assert.Equal(Money.Dollar(7).Currency(), result.Currency());
        }

        [Fact]
        public void TestReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce(Money.Dollar(1), "USD");

            Assert.True(result.Equals(Money.Dollar(1)));
        }

        [Fact]
        public void TestReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            var result = bank.Reduce(Money.Franc(2), "USD");

            Assert.True(Money.Dollar(1).Equals(result));
        }

        [Fact]
        public void TestIdentityRate()
        {
            Assert.Equal(1, new Bank().Rate("USD", "USD"));
        }
    }
}
