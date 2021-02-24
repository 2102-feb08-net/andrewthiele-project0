using System;

namespace proj0
{
  public class ConsoleInput : IKeyboardInput
  {
    public int RespondToPrompt(string message)
    {
      Console.WriteLine(message);
      return ReturnInteger();
    }

    public int ReturnInteger()
    {
      String input = "";
      int number;
      while (!Int32.TryParse(input, out number))
      {
        input = Console.ReadLine();
      }

      return number;
    }

    public int getIntegerBetweenExcludeMax(int min, int max)
    {
      bool isNotBetween = true;
      int integerInRange = max;
      while (isNotBetween)
      {
        integerInRange = ReturnInteger();
        if (integerInRange >= min && integerInRange < max)
        {
          isNotBetween = false;
        }
      }

      return integerInRange;
    }
    public bool isIntegerBetweenExcludeMax(int min, int max, int integer)
    {
      return integer >= min && integer < max ? true : false;
    }



    public int ChooseFrom(string[] menu)
    {
      for (int i = 0; i < menu.Length; ++i)
      {
        if (i == 0)
        {
          Console.WriteLine(menu[i]);
        }
        else
        {
          Console.WriteLine($"{i} - {menu[i]}");
        }
      }

      return ReturnInteger();
    }

    public String StringResponceToPrompt(String prompt)
    {
      Console.WriteLine(prompt);
      return Console.ReadLine();
    }
  }

}