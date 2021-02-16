using System;
using System.Collections.Generic;



namespace proj0
{
  public class Store
  {
    private String _storeID;
    private Dictionary<DateTime, Order> _storeOrderHistory;
    public Store(String ID)
    {
      Console.WriteLine("You watch the store");
      this._storeID = ID;

    }

    public void loadStoreData(String data)
    {

    }

    public bool isOutrageousAmount(int amount)
    {
      return false;
    }
  }
}
