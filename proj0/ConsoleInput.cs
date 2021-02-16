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
  }

}