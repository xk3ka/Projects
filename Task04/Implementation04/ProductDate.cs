using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation04
{
    public class ProductDate : Product
    {

        private int Date { get; set; }

        public ProductDate(string name, int price, int count, int date)
            : base(name, price, count)
        {
            Date = date;
        }

        protected override double Calculate()
        {
            return base.Calculate() + 0.5 * (2020 - Date);
        }

        public string GetProductDateInfo()
        {
            return GetProductInfo() + 
                "\nГод выпуска товара: " + Date; ;
        }

    }
}
