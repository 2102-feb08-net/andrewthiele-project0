namespace proj0
{
  public class Program
  {
    static void Main(string[] args)
    {
      ConsoleOutput cs = new ConsoleOutput();
      cs.Print2Screen("Store Application");


      var storeApp = new StoreApplication();
      storeApp.Start();

    }
  }
}
