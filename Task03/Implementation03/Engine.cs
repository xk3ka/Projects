using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation03
{
    public class Engine
    {
        private string Model { get; set; }
        private int Power { get; set; }
        public Engine(string model, int power)
        {
            Model= model;
            Power = power;
        }
        public string GetInfo()
        {
            return "\nМодель: " + Model +
                    "\nМощность: " + Power;
        }
    }
}
