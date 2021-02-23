using System;
using System.Collections.Generic;

namespace proj0
{
  public class Store
  {
    private ConsoleOutput co = new ConsoleOutput();
    private ConsoleInput ci = new ConsoleInput();

    private String _storeID;
    private Dictionary<String, Item> inventory;
    // private Dictionary<DateTime, Order> _storeOrderHistory;

    public Store(String id)
    {
      Console.WriteLine("You watch the store");
      this._storeID = id;
      inventory = new Dictionary<string, Item>();
    }

    public void LoadStoreData(String data)
    {

    }

    public bool IsOutrageousAmount(int amount)
    {
      return false;
    }

    public void PrintOutInventory()
    {
      Console.WriteLine($"Store {_storeID} Inventory is: ");
      foreach (KeyValuePair<string, Item> kvp in inventory)
      {
        Console.WriteLine($"{kvp.Value}");
      }
    }

    public bool isOutrageousAmount(int amount)
    {
      return false;
    }
  }
}
