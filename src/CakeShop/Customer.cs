using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop
{
    class Customer
    {
        private string name;
        private string customerID;
        private List<Cake> cakeHistory;

        public Customer(string name)
        {
            this.name = name;
            customerID = System.Guid.NewGuid().ToString();
            cakeHistory = new List<Cake>();
        }

        public string CustomerID
        {
            get { return customerID; }
        }

        public string Name
        {
            get { return name; }
        }

        public List<Cake> CakeHistory
        {
            get { return cakeHistory; }
        }

        public void AddCakeToHistory(Cake cake)
        {
            cakeHistory.Add(cake);
        }

        public override string ToString()
        {
            var orders = new List<string>();
            foreach (var cake in cakeHistory)
            {
                orders.Add(cake.ToString());
            }
            return "Customer history: " + orders;
        }
    }
}
