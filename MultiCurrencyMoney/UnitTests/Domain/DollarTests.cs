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
            var dollar = new Dollar(5);

            dollar.Times(2);

            Assert.Equal(10, dollar.Amount);
        }
    }
}
