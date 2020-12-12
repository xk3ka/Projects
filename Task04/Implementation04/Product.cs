using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation04
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }


        public Product(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        protected virtual double Calculate()
        {
            return (Price / Count);
        }

        private double GetQuality()
        {
            return Calculate();
        }

        public string GetProductInfo()
        {
            return "\nНаименование: " + Name +
                    "\nЦена: " + Price +
                    "\nКоличество: " + Count +
                    "\nКачество: " + GetQuality();
        }
    }
}
