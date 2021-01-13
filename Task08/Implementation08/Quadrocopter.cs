using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Quadrocopter
    {
        public event Abstraction.NeedHelp OnBreak;

        public Route Route { get; set; }
        public Coord MyCoord { get; set; }
        public Coord NextCoord { get; set; }
        public bool QuadStatus { get; set; }
        public bool NeedHelp { get; set; }
        public int DisabledChance { get; set; }
        public Random Random { get; set; }

        public Quadrocopter(Route route, Coord myCoord, int disableChance)
        {
            Route = route;
            MyCoord = myCoord;
            NextCoord = myCoord;
            DisabledChance = disableChance;
        }

        public void Start()
        {
            while (QuadStatus)
            {
                if (!NeedHelp)
                {
                    Move();
                }
                Thread.Sleep(200);
            }
        }

        public void Move()
        {
            if (NeedHelp)
            {
                return;
            }

            if (MyCoord.IsOn(NextCoord))
            {
                NextCoord = Route.Next();
            }
            else
            {
                if (IsBroken())
                {
                    OnBreak?.Invoke(this);
                    return;
                }
                MyCoord.Move(NextCoord);
            }

        }

        public bool IsBroken()
        {
            int x = Random.Next(0, 100);
            if (x < DisabledChance)
            {
                NeedHelp = true;
                return true;
            }
            return false;
        }
    }
}
