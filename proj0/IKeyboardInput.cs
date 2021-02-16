using System;
namespace proj0
{
    interface IKeyboardInput
    {
        int RespondToPrompt(String message);

        int ReturnInteger();

        int ChooseFrom(String[] menu);
      
    }

}
