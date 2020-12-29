using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation08
{
    public interface IMechanic
    {
        Image MechanicStay { get; set; }
        Image MechanicMove { get; set; }
        Coord BaseCoord { get; set; }
        Coord NextCoord { get; set; }

        void Start();
        bool OnBase();
        void GoTo(Coord coord);
        void NeedToBeFixed(Quadrocopter quad);
        void FixQuadrocopter(Quadrocopter quad);
        void Paint(Graphics g);
    }
}
