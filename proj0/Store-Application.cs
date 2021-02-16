using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace proj0
{
  public class StoreApplication
  {
    private ConsoleOutput co = new ConsoleOutput();
    private ConsoleInput ci = new ConsoleInput();
    private Dictionary<String, Customer> _customers = new Dictionary<string, Customer>();
    private Dictionary<String, Store> stores = new Dictionary<string, Store>();

    private void DisplayOrderDetails()
    {

    }

    private void DisplayStoreLocationHistory()
    {

    }

    private void DisplayCustomerOrderHistory()
    {

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
    public StoreApplication()
    { }

    /// <summary>
    /// Starts Store Application
    /// </summary>
    public void Start()
    {

      LoadStoreData();
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
            SearchCustomer();
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
      stores.Add("Chicago", new Store("CHICAGO1"));
      stores.Add("Baltimore", new Store("BALT1"));
      stores.Add("Arrlington", new Store("UTA1"));

    }

    private void AddCustomer()
    {
      // _customers.Add(ci.StringResponceToPrompt("Enter Customer ID"), new Customer(ci.StringResponceToPrompt("Enter first name"), ci.StringResponceToPrompt("Enter last name")));
      String CustomerName = ci.StringResponceToPrompt("Enter customer name");
      _customers.Add(CustomerName, new Customer(CustomerName));
    }

    private Customer SearchCustomer()
    {
      if (_customers.TryGetValue(ci.StringResponceToPrompt("Search customer by name"), out Customer foundCustomer))
      {
        // Console.WriteLine($"Found customer: {foundCustomer.FirstName} {foundCustomer.LastName}");
        Console.WriteLine($"Found customer: {foundCustomer.Name} ");
        Console.WriteLine($"YEAH!!!!");
        return foundCustomer;
      }
      else
      {
        co.Print2Screen("Customer not found");
        return null;
      }
    }
  }
}