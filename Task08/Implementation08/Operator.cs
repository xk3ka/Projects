using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Operator
    {
        public event Abstraction.OnQuad RemoteControl;

        public Quadrocopter Quadrocopter { get; set; }
        public Coord MyCoord { get; set; }

        public Operator(Quadrocopter quadrocopter, Coord myCoord)
        {
            Quadrocopter = quadrocopter;
            MyCoord = myCoord;
        }

        public void Start()
        {
            OnQuadrocopter();
        }

        public void OnQuadrocopter()
        {
            Thread.Sleep(100);
            Quadrocopter.QuadStatus = true;
            RemoteControl?.Invoke();
        }
    }
}
