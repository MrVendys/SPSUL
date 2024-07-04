using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekken
{
    public static class Extensions
    {
        public static double Distance(this Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X)* (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
