namespace proj0
{
  public class Program
  {
    static void Main(string[] args)
    {
      ConsoleOutput cs = new ConsoleOutput();
      cs.Print2Screen("Store Application");
      StoreApplication sa = new StoreApplication();
      sa.RunStoreApplication();
    }
  }
}
