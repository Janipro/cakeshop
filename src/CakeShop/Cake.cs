using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop
{
    class Cake
    {
        private string cakeType;
        private string customerID;
        private DateTime timeOrdered;
        private DateTime timeDelivered;

        public Cake(string cakeType, string customerID, DateTime timeOrdered)
        {
            this.cakeType = cakeType;
            this.customerID = customerID;
            this.timeOrdered = timeOrdered;
        }

        public string CakeType
        {
            get { return cakeType; }
        }

        public string CustomerID
        {
            get { return customerID; }
        }

        public DateTime TimeOrdered
        {
            get { return timeOrdered; }
        }

        public DateTime TimeDelivered
        {
            get { return timeDelivered; }
            set { timeDelivered = value; }
        }

        public Boolean IsDelivered()
        {
            return timeDelivered != null;
        }

        public override string ToString()
        {
            return "Cake: " + CakeType + ", time ordered: " + TimeOrdered + ", time delivered: " + TimeDelivered;
        }
    }
}
