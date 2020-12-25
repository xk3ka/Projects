using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Operator
    {
        public Quadrocopter Quadrocopter { get; set; }

        public Operator(Quadrocopter quadrocopter)
        {
            Quadrocopter = quadrocopter;
        }
        /*не понимаю что тут нужно*/
        public void Start()
        {
            OnQuadrocopter();
            while (true)
            {
                if (!Quadrocopter.QuadStatus)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            /*сломались((*/
        }

        public void OnQuadrocopter()
        {
            Thread.Sleep(1000);
            Quadrocopter.QuadStatus = true;
            /**/
        }
    }
}
