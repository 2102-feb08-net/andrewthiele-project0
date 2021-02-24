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

  public class Item_BoughtFromInventory
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

  public class Item_CanNotBeBoughtFromInventory
  {
    [Theory]
    [InlineData(int.MaxValue, 0)]
    [InlineData(int.MaxValue, int.MinValue)]


    public void CanBePurchasedWhenBuying_BoughtHigherThanAvailable_ReturnFalse(int bought, int available)
    {
      // arrange
      var item = new Item(available);
      // act
      bool result = item.CanBePurchasedWhenBuying(bought);
      // assert
      Assert.False(result, $"{bought} can be bought from {available}");
    }
  }

  public class Item_CanBeBoughtFromInventory
  {
    [Theory]
    [InlineData(0, int.MaxValue)]
    [InlineData(int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, int.MaxValue)]
    [InlineData(int.MinValue, int.MinValue)]
    [InlineData(0, 0)]


    public void CanBePurchasedWhenBuying_BoughtLowerThanAvailable_ReturnTrue(int bought, int available)
    {
      // arrange
      var item = new Item(available);
      // act
      bool result = item.CanBePurchasedWhenBuying(bought);
      // assert
      Assert.True(result, $"{bought} can not be bought from {available}");
    }
  }
  public class ConsoleInput_IntegerIsNotBetweenExcludeMax
  {
    [Theory]
    [InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
    [InlineData(int.MinValue, int.MinValue, int.MinValue)]
    [InlineData(int.MinValue, int.MaxValue, int.MaxValue)]
    [InlineData(int.MaxValue, int.MinValue, int.MinValue)]
    [InlineData(int.MaxValue, int.MinValue + 1, int.MinValue)]
    [InlineData(int.MaxValue, int.MaxValue, int.MaxValue - 1)]


    public void isIntegerBetweenExcludeMax_InputOutOfBounds_ReturnFalse(int min, int max, int test)
    {
      // arrange
      var ci = new ConsoleInput();
      // act
      bool result = ci.isIntegerBetweenExcludeMax(min, max, test);
      // assert
      Assert.False(result, $"{test} is >= {min} and < {max}");
    }
  }
  public class ConsoleInput_IntegerIsBetweenExcludeMax
  {
    [Theory]
    [InlineData(int.MinValue, int.MinValue + 1, int.MinValue)]
    [InlineData(int.MinValue, int.MaxValue, int.MaxValue - 1)]

    public void isIntegerBetweenExcludeMax_InputOutOfBounds_ReturnFalse(int min, int max, int test)
    {
      // arrange
      var ci = new ConsoleInput();
      // act
      bool result = ci.isIntegerBetweenExcludeMax(min, max, test);
      // assert
      Assert.True(result, $"{test} is NOT >= {min} and < {max}");
    }
  }
}
