using System;

namespace proj0
{
  /// <summary>
  /// This is the customer class
  /// </summary>
  public class Customer
  {

    private String fname;
    private String lname;

    public Customer()
    {
      this.fname = "John";
      this.lname = "Doe";
    }

    public Customer(String fname, String lname)
    {
      this.fname = fname;
      this.lname = lname;
    }

    public String FirstName
    {
      get => this.fname;
      set => fname = value;
    }

    public String LastName
    {
      get => this.lname;
      set => lname = value;
    }

    public bool IsPrime(int candidate)
    {
      if (candidate < 2)
      {
        return false;
      }
      throw new NotImplementedException("not fully implemented");
    }
  }
}
