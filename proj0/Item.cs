using System;

namespace proj0
{
  public class Item
  {
    private String _itemName;
    private int _quantity;
    public Item()
    {
      this._itemName = "Thing1";
      this._quantity = 0;
    }
    public Item(String itemName, int quantity)
    {
      this._itemName = itemName;
      this._quantity = quantity;
    }

    public Item(int quantity)
    {
      this._quantity = quantity;
    }

    public String ItemName
    {
      get { return _itemName; }
      // need to sanitize value
      set { _itemName = value; }
    }
    /// <summary>
    /// Updates amount of product in inventory after customer purchase
    /// If passed amount is negative it is set to zero
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int BoughtFromInventory(int amount)
    {
      if (amount < 0)
      {
        amount = 0;
      }
      return CanBePurchasedWhenBuying(amount) ? this._quantity -= amount : this._quantity;
    }
    /// <summary>
    /// Determines whether a purchase can be made. 
    /// Checks if desired purchased amount <= stock amount
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool CanBePurchasedWhenBuying(int amount)
    {
      return _quantity >= amount;
    }
  }
}