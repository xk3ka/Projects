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
        public Image QuadOff = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\quadOff.png");
        public Image QuadOn = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\quadOn.png");
        public Image QuadBoom = Image.FromFile("A:\\source\\ISIT\\Task08\\resources\\quadBoom.png");

        public event Emulator.MethodContainer OnActionWriting;

        public event Emulator.NeedHelp OnBreak;
        /*нужен еще какой то путь
        либо определенный
        либо по кругу мб летать
         */
        /*public bool BrokenStatus { get; set; } типо вообще сломался если за какое то время не успели подчинить, потом попробовать сделать */
        public bool BrokenStatus { get; set; }
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

        public virtual void OnActionWritingFunction(string message)
        {
            OnActionWriting?.Invoke(message);
        }

        public void Move()
        {
            if (NeedHelp)
            {
                OnActionWritingFunction("сломались");
                return;
            }
            if (MyCoord.IsOn(NextCoord))
            {
                OnActionWritingFunction("остановились, ждем некст коорд");
                NextCoord = Route.Next();
            }
            else
            {
                if (IsBroken())
                {
                    OnActionWritingFunction("Сломались ждем механика");
                    OnBreak?.Invoke(this);
                    return;
                }
                OnActionWritingFunction("Катим дальше");
                MyCoord.Move(NextCoord);
            }

        }

        public bool IsBroken()
        {
            int x = Random.Next(0, 100);
            if (x < DisabledChance)
            {
                BrokenStatus = true;
                NeedHelp = true;
                return true;
            }
            return false;
        }

        public void Paint(Graphics g)
        {
            /*if() сломался то сломался*/

            if (!NeedHelp)
            {
                g.DrawImage(QuadOn,MyCoord.X,MyCoord.Y,100,100);
            }
            else
            {
                g.DrawImage(QuadOff, MyCoord.X, MyCoord.Y, 100, 100);
            }
        }
    }
}
