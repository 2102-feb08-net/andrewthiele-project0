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
            Console.WriteLine("Search Customers");
            SearchCustomer();
            break;
          case (int)storeAppChoices.OrderDetailDisplay:
            Console.WriteLine("Search Orders");
            // placeorder
            break;
          case (int)storeAppChoices.StoreOrderHistoryDisplay:
            Console.WriteLine("Store Order Histroy ...");
            DisplayCustomerStoreHistory();
            break;
          case (int)storeAppChoices.CustomerOrderHistroyDisplay:
            Console.WriteLine("Customer Order History ...");
            DisplayCustomerOrderHistory();
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

    private void AddCustomer()
    {
      String fname = ci.StringResponceToPrompt("Enter first name");
      String lname = ci.StringResponceToPrompt("Enter last name");

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

    private void SearchCustomer()
    {
      var context = createContext(_filelocation, _logStreamLocation);
      // Console.WriteLine("Context Created");

      String searchedFirstName = ci.StringResponceToPrompt("Enter customer first name: ");
      String searchedLastName = ci.StringResponceToPrompt("Enter customer last name: ");

      try
      {
        var result = context.Customers
              .Where(c => c.FirstName == searchedFirstName && c.LastName == searchedLastName).SingleOrDefault();
        if (result.FirstName.Equals(searchedFirstName) && result.LastName.Equals(searchedLastName))
        {
          decimal balance = Math.Truncate(result.Balance * 100) / 100;

          string s = string.Format(balance.ToString(), "{0:0.00}%");
          Console.WriteLine($"Customer {result.FirstName} {result.LastName} found with a balance of {s}");
          // Console.WriteLine("WOO HOO");
        }
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("No Customer found");
      }

    }

    private void DisplayCustomerOrderHistory()
    {
      Console.WriteLine("I am totally showing the customer order history");
      var context = createContext(_filelocation, _logStreamLocation);
      // Console.WriteLine("Context Created");

      String searchedFirstName = ci.StringResponceToPrompt("Enter customer first name: ");
      String searchedLastName = ci.StringResponceToPrompt("Enter customer last name: ");

      try
      {
        var result = context.Customers
              .Where(c => c.FirstName == searchedFirstName && c.LastName == searchedLastName).SingleOrDefault();
        if (result.FirstName.Equals(searchedFirstName) && result.LastName.Equals(searchedLastName))
        {

          Console.WriteLine($"Order history for {result.FirstName} {result.LastName}");
          var orderHistory = context.Orders
          .Include(o => o.Product)
          .Include(o => o.Invoice)
            .ThenInclude(i => i.Customer)
          .Include(o => o.Invoice)
            .ThenInclude(i => i.Location)
          .Where(o => (o.Invoice.Customer.FirstName == searchedFirstName && o.Invoice.Customer.LastName == searchedLastName))
          .OrderBy(o => o.Invoice.TimeOfOrder)
          .ToList();


          Console.WriteLine($"{result.FirstName} {result.LastName} has ordered: ");

          foreach (var order in orderHistory)
          {
            Console.WriteLine($"******************************");
            Console.WriteLine($"Invoice ID: {order.InvoiceId}");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Product: {order.Product.Name}");
            Console.WriteLine($"From Location: {order.Invoice.Location.Address1}");
            Console.WriteLine($"              {order.Invoice.Location.Address2}");
            Console.WriteLine($"City: {order.Invoice.Location.City}");
            Console.WriteLine($"State: {order.Invoice.Location.State}");
            Console.WriteLine($"******************************");
          }
        }
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("No Customer found");
      }
    }
    private void DisplayCustomerStoreHistory()
    {
      Console.WriteLine("I am totally showing the store order history");
      var context = createContext(_filelocation, _logStreamLocation);
      // Console.WriteLine("Context Created");

      String locationIdIs = ci.StringResponceToPrompt("Enter location code: ");

      try
      {
        var result = context.Locations
              .Where(l => l.LocationId.ToString() == locationIdIs).SingleOrDefault();
        if (result.LocationId.Equals(locationIdIs))
        {
          var orderHistory = context.Orders
          .Include(o => o.Product)
          .Include(o => o.Invoice)
            .ThenInclude(i => i.Location)
          .Include(o => o.Invoice)
            .ThenInclude(i => i.Customer)
          .Where(o => (o.Invoice.LocationId.ToString() == locationIdIs))
          .OrderBy(o => o.Invoice.TimeOfOrder)
          .ToList();

          Console.WriteLine($"Order history for Location ID: {result.Nickname}");
          Console.WriteLine($"Address : {result.Address1}");
          Console.WriteLine($"Address : {result.Address2}");
          Console.WriteLine($"City : {result.City}");
          Console.WriteLine($"State : {result.State}");

          foreach (var order in orderHistory)
          {
            Console.WriteLine($"******************************");
            Console.WriteLine($"Invoice ID: {order.InvoiceId}");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Product: {order.Product.Name}");
            Console.WriteLine($"From Customer: {order.Invoice.Customer.FirstName} {order.Invoice.Customer.LastName}");
            Console.WriteLine($"******************************");
          }
        }
      }
      catch (NullReferenceException)
      {
        Console.WriteLine("No Store found");
      }

    }
  }
}