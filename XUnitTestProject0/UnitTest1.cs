using System;
using Xunit;
using proj0;

namespace XUnitTestProject0
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var customer = new Customer();
            bool result = customer.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}
