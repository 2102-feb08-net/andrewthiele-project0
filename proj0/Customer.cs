using System;

namespace proj0
{
  /// <summary>
  /// This is the customer class
  /// </summary>
  public class Customer
  {
    // private int _customerId;
    private String _fname;
    private String _lname;

    // private double _balance;

    public Customer()
    {

      this._fname = "DEFAULT";
      this._lname = "CUSTOMER";
    }

    public Customer(String fname, String lname)
    {
      this._fname = fname;
      this._lname = lname;
    }

    public String FirstName
    {
      get => this._fname;
      set => _fname = value;
    }

    public String LastName
    {
      get => this._lname;
      set => _lname = value;
    }

    public String FullName
    {
      get => this._fname + this._lname;
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
