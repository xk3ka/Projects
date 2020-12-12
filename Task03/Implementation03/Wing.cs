using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation03
{
    public class Wing
    {
        private int Size { get; set; }
        private string Model { get; set; }
        public Wing(int size, string model)
        {
            Size = size;
            Model = model;
        }

        public string GetInfo()
        {
            return "\nРазмер: " + Size +
                    "\nМодель: " + Model;
        }
    }
}
