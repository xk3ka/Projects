using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation08
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Step { get; set;}

        public Coord(int x, int y, int step)
        {
            X = x;
            Y = y;
            Step = step;
        }

        public int Distance(Coord coord)
        {
            return (int)Math.Sqrt((X - coord.X) * (X - coord.X) + (Y - coord.Y) * (Y - coord.Y));
        }

        public bool IsOn(Coord coord)
        {
            return Math.Abs(coord.X - X) < Step && Math.Abs(coord.Y - Y) < Step;
        }

        public void Move(Coord coord)
        {
            int xStep = Math.Abs(X - coord.X) < Step ? Math.Abs(X - coord.X) : Step;
            if (X > coord.X)
                X -= xStep;
            else if (X < coord.X)
                X += xStep;

            int yStep = Math.Abs(Y - coord.Y) < Step ? Math.Abs(Y - coord.Y) : Step;

            if (Y > coord.Y)
                Y -= yStep;
            else if (Y < coord.Y)
                Y += yStep;
        }
    }
}
