using System;

namespace proj0
{
  public class Item
  {
    private String itemName;
    // private int quantity;
    public Item() { }

    public String ItemName
    {
      get { return itemName; }
      // need to sanitize value
      set { itemName = value; }
    }

  }
}