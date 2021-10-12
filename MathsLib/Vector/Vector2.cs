using System;
using System.Collections.Generic;
using System.Text;

namespace MathsLib
{
    class Vector2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2(double a, double b)
        {
            x = a;
            y = b;
        }

        public Vector2()
        {
            x = 0; y = 0;
        }

        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y);
        }




    }
}
