﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Mechanic : IMechanic
    {
        public Coord BaseCoord { get; set; }
        public Coord NextCoord { get; set; }

        public List<Quadrocopter> HelpList { get; set; } = new List<Quadrocopter>();

        public Mechanic(Coord baseCoord,Coord nextCoord)
        {
            BaseCoord = baseCoord;
            NextCoord = nextCoord;
        }

        public Mechanic()
        {

        }

        public void FixQuadrocopter(Quadrocopter quad)
        {
            Thread.Sleep(2000);
            quad.NeedHelp = false;
            HelpList.Remove(quad);
        }

        public void GoTo(Coord coord)
        {
            Thread.Sleep(100);
            if (!NextCoord.IsOn(coord))
            {
                NextCoord.Move(coord);
            }
        }

        public void NeedToBeFixed(Quadrocopter quad)
        {
            HelpList.Add(quad);
        }

        public bool OnBase()
        {
            return NextCoord.IsOn(BaseCoord);
        }

        public void Start()
        {
                while (true)
                {
                    if (HelpList.Count == 0)
                    {
                        GoTo(BaseCoord);
                    }
                    else
                    {
                        Quadrocopter q = HelpList[0];
                        while (!NextCoord.IsOn(q.MyCoord))
                        {
                            GoTo(q.MyCoord);
                        }
                        FixQuadrocopter(q);
                    }
                }
        }
    }
}