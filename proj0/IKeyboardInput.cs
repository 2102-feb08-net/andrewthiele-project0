using System;

public interface IKeyboardInput
{
	public int RespondToPrompt(String message)
    {}

    public int ChooseFrom(String[] menu)
    {}
}
