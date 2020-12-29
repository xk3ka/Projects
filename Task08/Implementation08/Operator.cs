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
        public event Emulator.OnQuad OnQuad;
        public Quadrocopter Quadrocopter { get; set; }

        public Image OperatorOff = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\operatorOff.png");
        public Image OperatorOn = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\operatorOn.png");
        public Image OperatorBroken = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\operatorBroken.png");

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
                Thread.Sleep(100);
            }
            /*сломались((*/
        }

        public void OnQuadrocopter()
        {
            Thread.Sleep(100);
            Quadrocopter.QuadStatus = true;
            OnQuad?.Invoke(this);
            /**/
        }

        public void Paint(Graphics g)
        {

            if (Quadrocopter.QuadStatus)
            {
                g.DrawImage(OperatorOn, 10, 10, 100, 100);
            }
            else
            {
                g.DrawImage(OperatorOn, 10, 10, 100, 100);
            }
        }
    }
}
