using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation03
{
    public class Chassis
    {
        public string Model { get; set; }
        public int Size { get; set; }

        public Chassis(string model, int size)
        {
            Model = model;
            Size = size;
        }

        public string GetInfo()
        {
            return "\nРазмер: " + Size +
                    "\nМодель: " + Model;
        }
    }
}
