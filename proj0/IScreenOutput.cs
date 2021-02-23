using System;

namespace proj0
{
  interface IScreenOutput
  {
    void Print2Screen(String output);
    void Print2Screen(int number);

    void PrintMenu2Screen(String[] menu);
  }
}
