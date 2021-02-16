using System;

namespace proj0
{
	public class ConsoleOutput : IScreenOutput
	{
		public ConsoleOutput()
		{}

		public void Print2Screen(String message)
        {
			Console.WriteLine(message);
        }

		public void Print2Screen(int number)
        {
			Console.WriteLine(number);
        }
	}
}
