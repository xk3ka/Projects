using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Abstraction
    {
        public delegate void NeedHelp(Quadrocopter quad);
        public delegate void OnQuad();

        public List<Operator> Operators { get; set; } = new List<Operator>();
        private List<Thread> Threads { get; set; } = new List<Thread>();

        public IMechanic Mechanic { get; set; }
        public Random Random { get; set; }

        public Abstraction(List<Operator> operators, IMechanic mechanic)
        {
            Operators = operators;
            Mechanic = mechanic;
            Random = new Random();
        }

        public void Start()
        {
            foreach(Operator @operator in Operators)
            {
                @operator.Quadrocopter.Random = Random;
                @operator.Quadrocopter.OnBreak += Mechanic.NeedToBeFixed;
                @operator.RemoteControl += @operator.Quadrocopter.Start;

                Thread operatorThread = new Thread(@operator.Start);
                operatorThread.Start();
                Threads.Add(operatorThread);
            }
            Thread mechanicThread = new Thread(Mechanic.Start);
            mechanicThread.Start();
            Threads.Add(mechanicThread);
        }

        public void Stop()
        {
            foreach (Thread thread in Threads)
            {
                thread.Abort();
            }
        }
    }
}
