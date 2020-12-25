using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Quadrocopter
    {
        public event Emulator.NeedHelp OnBreak;
        /*нужен еще какой то путь
        либо определенный
        либо по кругу мб летать
         */
        /*public bool BrokenStatus { get; set; } типо вообще сломался если за какое то время не успели подчинить, потом попробовать сделать */
        public Route Route { get; set; }
        public Coord MyCoord { get; set; }
        public Coord NextCoord { get; set; }
        public Operator Operator { get; set; }
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
                Move();
                Thread.Sleep(100);
            }
        }

        public void Move()
        {
            if (NeedHelp)
            {
                /*чет происходит*/
                return;
            }
            if (MyCoord.IsOn(NextCoord))
            {
                /*чет происходит*/
                NextCoord = Route.Next();
            }
            else
            {
                if (IsBroken())
                {
                    OnBreak?.Invoke(this);
                    return;
                }
                /*чет происходит*/
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
