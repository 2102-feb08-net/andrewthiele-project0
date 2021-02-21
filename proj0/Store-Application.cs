using System;
using System.Collections.Generic;
using System.Linq;
using StoreApp.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;



namespace proj0
{
  public class StoreApplication
  {

    private String _filelocation;
    private String _logStreamLocation;




    public String Filelocation
    {
      get => _filelocation;
    }

    public String LogStreamLocation
    {
      get => _logStreamLocation;
    }
    private ConsoleOutput co = new ConsoleOutput();
    private ConsoleInput ci = new ConsoleInput();
    private Dictionary<String, Customer> _customers = new Dictionary<string, Customer>();
    private Dictionary<String, Store> stores = new Dictionary<string, Store>();

    private Order currentOrder = new Order();


    private void DisplayOrderDetails()
    {

    }

    private void DisplayStoreLocationHistory()
    {

    }

    private void DisplayCustomerOrderHistory()
    {

    }

    private StoreProj0Context createContext(String filelocation, String logger)
    {
      // using var logStream = new StreamWriter(logger, append: false) { AutoFlush = true };
      //var logStream = new StreamWriter(logger, append: false) { AutoFlush = true };

      String connectionString = File.ReadAllText(filelocation);
      DbContextOptions<StoreProj0Context> options = new DbContextOptionsBuilder<StoreProj0Context>()
        .UseSqlServer(connectionString)
        //.LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
        .Options;

      return new StoreProj0Context(options);
    }

    private String[] storeAppOperations = { "Store App Operations", "Place order to store location for customer", "Add new customer", "Search customers by name", "Display order details", "Display store location order history", "Display customer order history", "Exit Application" };

    enum storeAppChoices
    {
      PlaceOrder = 1,
      AddCusomer,
      SearchCustomer,
      OrderDetailDisplay,
      StoreOrderHistoryDisplay,
      CustomerOrderHistroyDisplay,
      ExitProgram

    }
    public StoreApplication(String filelocation, String logStreamLocation)
    {
      this._filelocation = filelocation;
      this._logStreamLocation = logStreamLocation;
    }

    /// <summary>
    /// Starts Store Application
    /// </summary>
    public void Start()
    {

      //LoadStoreData();
      bool isStillUsingApp = true;

      while (isStillUsingApp)
      {
        switch (ci.ChooseFrom(storeAppOperations))
        {
          case (int)storeAppChoices.PlaceOrder:
            Console.WriteLine("Order placed");
            // placeorder
            break;
          case (int)storeAppChoices.AddCusomer:
            Console.WriteLine("Add Customer");
            AddCustomer();
            break;
          case (int)storeAppChoices.SearchCustomer:
            Console.WriteLine("Search Customer");
            SearchCustomer("Search customer by name");
            break;
          case (int)storeAppChoices.OrderDetailDisplay:
            Console.WriteLine("Order placed");
            // placeorder
            break;
          case (int)storeAppChoices.StoreOrderHistoryDisplay:
            Console.WriteLine("Order placed");
            // placeorder
            break;
          case (int)storeAppChoices.CustomerOrderHistroyDisplay:
            Console.WriteLine("Order placed");
            // placeorder
            break;
          case (int)storeAppChoices.ExitProgram:
            Console.WriteLine("Exiting ...");
            isStillUsingApp = false;
            // placeorder
            break;
          default:
            co.Print2Screen("Please make a valid selection");
            break;
        }

      }
      co.Print2Screen("");
      co.Print2Screen("Application Exited");
    }

    private void LoadStoreData()
    {

    }

    private void AddCustomer()
    {
      String fname = ci.StringResponceToPrompt("Enter first name");
      String lname = ci.StringResponceToPrompt("Enter last name");

      // _customers.Add($"{fname} {lname}", new Customer(fname, lname));
      var context = createContext(_filelocation, _logStreamLocation);

      int max_id = context.Customers.Max(c => c.CustomerId);
      // Console.WriteLine("Context created");
      var newCustomer = new StoreApp.DbAccess.Customer
      {
        CustomerId = ++max_id,
        FirstName = fname,
        LastName = lname,
        Balance = 0M
      };

      context.Customers.Add(newCustomer);
      context.SaveChanges();

      Console.WriteLine("Customer Added");
      context.Dispose();

    }

    private void SearchCustomer(String searchMessage)
    {
      // if (_customers.TryGetValue(ci.StringResponceToPrompt(searchMessage), out Customer foundCustomer))
      // {
      //   Console.WriteLine($"Found customer: {foundCustomer.FirstName} {foundCustomer.LastName}");
      //   co.Print2Screen($"YEAH!!!!");
      //   return foundCustomer;
      // }
      // else
      // {
      //   co.Print2Screen("Customer not found");
      //   return null;
      // }

      var context = createContext(_filelocation, _logStreamLocation);
    }
  }
}