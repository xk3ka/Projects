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
        public List<Quadrocopter> Quadrocopters { get; set; } = new List<Quadrocopter>();
        public IMechanic Mechanic { get; set; }

        private List<Thread> Threads = new List<Thread>();

        public delegate void NeedHelp(Quadrocopter quad);

        public Emulator(List<Quadrocopter> quadrocopters, IMechanic mechanic)
        {
            Quadrocopters = quadrocopters;
            Mechanic = mechanic;
        }

        public void Start()
        {
            foreach(Quadrocopter quad in Quadrocopters)
            {
                quad.OnBreak += Mechanic.NeedToBeFixed;
                Thread quadThread = new Thread(quad.Start);
                quadThread.Start();
                Thread operatorThread = new Thread(quad.Operator.Start);
                operatorThread.Start();
                Threads.Add(quadThread);
                Threads.Add(operatorThread);
            }
            Thread mechanicThread = new Thread(Mechanic.Start);
            mechanicThread.Start();
            Threads.Add(mechanicThread);
        }

        public void Stop()
        {
            foreach (var thread in Threads)
            {
                thread.Abort();
            }
        }
    }
}
