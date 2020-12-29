using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Emulator
    {
        public List<Operator> Operators { get; set; } = new List<Operator>();
        public IMechanic Mechanic { get; set; }

        private List<Thread> Threads = new List<Thread>();

        public delegate void NeedHelp(Quadrocopter quad);
        public delegate void OnQuad(Operator op);

        public Emulator(List<Operator> operators, IMechanic mechanic)
        {
            Operators = operators;
            Mechanic = mechanic;
        }

        public void Start()
        {
            foreach(Operator @operator in Operators)
            {
                Thread operatorThread = new Thread(@operator.Start);
                operatorThread.Start();
                @operator.Quadrocopter.OnBreak += Mechanic.NeedToBeFixed;
                Thread quadThread = new Thread(@operator.Quadrocopter.Start);
                quadThread.Start();
                Threads.Add(operatorThread);
                Threads.Add(quadThread);
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
