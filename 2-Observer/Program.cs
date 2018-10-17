using System;
using System.Collections.Generic;
using System.Linq;
namespace _2_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock Ibm = new Stock { Name = "IBM", Price = 44 };
            Ibm.Attach(new Investor() { Name = "Joe" });
            Ibm.Attach(new Investor() { Name = "Mark" });
            Ibm.Price = 55;
            Ibm.Price = 66;
        }
    }

    class Stock
    {
        public string Name { get; set; }
        double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyAll();
            }
        }

        private List<Investor> Subscribes = new List<Investor>();

        public void Attach(Investor investor)
        {
            Subscribes.Add(investor);
        }

        public void Detatch(Investor investor)
        {
            Subscribes.Remove(investor);
        }

        private void NotifyAll()
        {
            Subscribes.ForEach(x => x.Update(this));
        }
    }

    class Investor
    {
        public string Name { get; set; }
        public void Update(Stock stock)
        {
            Console.WriteLine($"Notified {Name}: {stock.Name} {stock.Price}");
        }
    }
}
