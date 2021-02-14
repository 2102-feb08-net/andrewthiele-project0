using System;

namespace proj0
{
    public class Customer
    {
        public Customer()
        {
            Console.WriteLine("WHat me worry?");
        }

        public void loadCustomerData()
        {

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

    public class Store
    {
        public Store()
        {
            Console.WriteLine("You watch the store");
        }

        public void loadStoreData(String data)
        {

        }
    }

    public class Program
    {
        
        static void Main(string[] args)
        {
            var customer = new Customer();
        }
    }
}
