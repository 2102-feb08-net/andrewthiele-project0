using System;

namespace proj0
{
  public class ConsoleOutput : IScreenOutput
  {
    public ConsoleOutput()
    { }
    /// <summary>
    /// Prints message to console
    /// </summary>
    /// <param name="message"></param>
    public void Print2Screen(String message)
    {
      Console.WriteLine(message);
    }
    /// <summary>
    /// Prints a number to the screee
    /// </summary>
    /// <param name="number"></param>
    public void Print2Screen(int number)
    {
      Console.WriteLine(number);
    }
    /// <summary>
    /// Prints menu options to console
    /// </summary>
    /// <param name="menu"></param>
    public void PrintMenu2Screen(String[] menu)
    {
      for (int i = 0; i < menu.Length; ++i)
      {
        if (i != 0)
        {
          Console.WriteLine($"{i} - {menu[i]}");
        }
        else
        {
          Console.WriteLine($"{menu[i]}");
        }

      }
    }
  }
}
