//using DatabaseFirst; // CHinook object came from here
using StoreApp.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace proj0
{
  public class Program
  {
    static void Main(string[] args)
    {
      string filelocation = "C:/Revature/storeApp-connection-string.txt";

      string logStreamLocation = "EF-LOG.txt";

      // using var logStream = new StreamWriter("EF-LOG.txt", append: false) { AutoFlush = true };

      // String connectionString = File.ReadAllText(filelocation);
      // DbContextOptions<StoreProj0Context> options = new DbContextOptionsBuilder<StoreProj0Context>()
      //   .UseSqlServer(connectionString)
      //   .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
      //   .Options;

      // using var context = new StoreProj0Context(options);
      //using var context = StoreMaker(filelocation, logStreamLocation);

      //DisplayItems(context);

      // ! EXPERIMENTAL CODE //
      Console.WriteLine("THERE IS NO DISPLAYING ITEMS");
      var storeLocation = new StoreApplication(filelocation, logStreamLocation);
      storeLocation.Start();

      // ! EXPERIMENTAL CODE FINISH //


    }

    static void DisplayItems(StoreProj0Context context)
    {
      Console.WriteLine("I am totally going to display Items");

      var query = context.Products
      .Select(p => p);

      foreach (var item in query)
      {
        Console.WriteLine($"There are {item.Quantity} {item.Name} each with a price of {item.Price}");
      }
    }

    // static StoreProj0Context StoreMaker(String filelocation, String logger)
    // {
    //   // using var logStream = new StreamWriter(logger, append: false) { AutoFlush = true };
    //   var logStream = new StreamWriter(logger, append: false) { AutoFlush = true };

    //   String connectionString = File.ReadAllText(filelocation);
    //   DbContextOptions<StoreProj0Context> options = new DbContextOptionsBuilder<StoreProj0Context>()
    //     .UseSqlServer(connectionString)
    //     .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
    //     .Options;

    //   return new StoreProj0Context(options);
    // }
  }
}
