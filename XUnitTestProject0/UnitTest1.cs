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
    //[InlineData(2)]
    public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
    {
      // arange 
      // act
      // assert
      var customer = new Customer("Larry", "Jones");
      bool result = customer.IsPrime(value);

      Assert.False(result, $"{value} should not be prime");
    }
  }

  // public class InputValidationTests
  // {
  //   const int MIN = 0;
  //   const int MAX = 5;
  //   [Theory]
  //   [InlineData(0, MIN, MAX)]
  //   [InlineData(1, MIN, MAX)]
  //   [InlineData(2, MIN, MAX)]
  //   [InlineData(3, MIN, MAX)]
  //   [InlineData(4, MIN, MAX)]

  //   public void GetIntegerBetweenExcludeMax_IsBetweenMin0AndMax5_ReturnTrue(int value, int min, int max)
  //   {
  //     // arrange
  //     var ci = new ConsoleInput();
  //     // act
  //     int returnedInteger = ci.getIntegerBetweenExcludeMax(min, max);

  //     // assert
  //     Assert.True(returnedInteger == value, $"{returnedInteger} and {value} should be equal");
  //   }
  // }

  public class ItemTests
  {
    [Theory]
    [InlineData(3, 5, 2)]
    [InlineData(12, 1, 1)]
    [InlineData(12, 0, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 0, 0)]
    [InlineData(-1, 1, 1)]


    public void BoughtFromInventory_ValuesLessThanInInventory_ReturnTrue(int bought, int available, int remaining)
    {
      // arrange
      var item = new Item("", available);

      // act
      int remainingInInventory = item.BoughtFromInventory(bought);
      // assert
      Assert.Equal(remainingInInventory, remaining);

    }
  }
}
