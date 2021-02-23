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

    public String ItemName
    {
      get { return _itemName; }
      // need to sanitize value
      set { _itemName = value; }
    }

    public int WasSold
    {
      set { _quantity -= value; }
    }

  }
}