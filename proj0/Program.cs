namespace proj0
{
  public class Program
  {
    static void Main(string[] args)
    {
      var customer = new Customer();
            var CI = new ConsoleInput();
            var CO = new ConsoleOutput();
            CO.Print2Screen(CI.RespondToPrompt("Type in an integer: "));
    }
  }
}
