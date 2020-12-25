using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Route
    {
        public List<Coord> RouteCoord { get; set; }

        private int index = 0;

        public Route(List<Coord> routeCoord)
        {
            RouteCoord = routeCoord;
        }

        public Coord Next()
        {
            if (index < RouteCoord.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            return RouteCoord[index];
        }
    }
}
