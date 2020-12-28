using System;
using System.IO;
using System.Collections.Generic;

namespace CakeShop
{
    class CakeShop
    {
        private List<Cake> orderedCakes;
        private List<Cake> deliveredCakes;
        private List<Customer> customers;

        public CakeShop()
        {
            orderedCakes = new List<Cake>();
            deliveredCakes = new List<Cake>();
            customers = new List<Customer>();
        }

        public void RegisterCustomer(string name)
        {
            var customer = new Customer(name);
            if (!customers.Contains(customer)){
                customers.Add(customer);
            }
        }

        public void OrderCake(string customerID, string cakeType, DateTime localTime)
        {
            foreach (var customer in customers)
            {
                if (customer.CustomerID.Equals(customerID))
                {
                    var cake = new Cake(customerID, cakeType, localTime);
                    orderedCakes.Add(cake);
                    customer.AddCakeToHistory(cake);
                }
            }
        }

        public void DeliverCake(string customerID, string cakeType, DateTime localTime)
        {
            foreach (var cake in orderedCakes)
            {
                if (cake.CustomerID.Equals(customerID) && cake.CakeType.Equals(cakeType))
                {
                    orderedCakes.Remove(cake);
                    deliveredCakes.Add(cake);
                    cake.TimeDelivered = localTime;
                    return;
                }
            } 
            throw new ArgumentException("Can't deliver cake");
        }

        public string CustomerInfo(string customerID)
        {
            foreach (var customer in customers)
            {
                if (customer.CustomerID.Equals(customerID))
                {
                    return "Customer name: " + customer.Name + "Customer info: " + customer.ToString();
                }
            }
            return "Customer could not be found!";
        }

        public List<Customer> Customers()
        {
            return customers;
        }

        public string OldestCake()
        {
            long result = 0;
            foreach (var cake in deliveredCakes)
            {
                long diff = cake.TimeDelivered.Ticks - cake.TimeOrdered.Ticks;
                if (diff > result)
                {
                    result = diff;
                }
            }
            return "The oldest cake is: " + result + "ticks old.";
        }
    }
}
