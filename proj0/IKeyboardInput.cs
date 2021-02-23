using System;
namespace proj0
{
  interface IKeyboardInput
  {
    int RespondToPrompt(String message);

    int ReturnInteger();

    int getIntegerBetweenExcludeMax(int min, int max);

    int ChooseFrom(String[] menu);

  }

}
