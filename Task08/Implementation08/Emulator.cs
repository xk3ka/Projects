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
        public List<Operator> Operators { get; } = new List<Operator>();
        public IMechanic Mechanic { get; }

        private List<Thread> Threads = new List<Thread>();

        public delegate void NeedHelp(Quadrocopter quad);
        public delegate void OnQuad(Operator op);

        public delegate void MethodContainer(string message);

        private Random random;

        public Emulator(List<Operator> operators, IMechanic mechanic)
        {
            Operators = operators;
            Mechanic = mechanic;
            random = new Random();
        }

        public void Start()
        {
            foreach(Operator @operator in Operators)
            {
                @operator.Quadrocopter.OnActionWriting += EchoFunc;
                @operator.OnActionWriting += EchoFunc;
                @operator.Quadrocopter.OnActionWriting += EchoFunc;
                @operator.Quadrocopter.Random = random;
                @operator.Quadrocopter.OnBreak += Mechanic.NeedToBeFixed;
                Thread operatorThread = new Thread(@operator.Start);
                operatorThread.Start();
                Thread quadThread = new Thread(@operator.Quadrocopter.Start);
                quadThread.Start();
                Threads.Add(operatorThread);
                Threads.Add(quadThread);
            }
            Thread mechanicThread = new Thread(Mechanic.Start);
            mechanicThread.Start();
            Threads.Add(mechanicThread);
        }

        public void EchoFunc(string message)
        {
            Console.WriteLine(message);
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
