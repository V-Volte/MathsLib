using System;
using System.Collections.Generic;
using System.Text;


namespace MathsLib
{
    class Complex
    {
        public double Imaginary { get; set; }
        public double Real {get; set;}

        public static StringType stringType = StringType.Rectangular;

        public static AngleUnits angleUnits = AngleUnits.Rad;

        public static bool displayDouble = false;


        public Complex(double re, double im)
        {
            Imaginary = im;
            Real = re;
        }

        public Complex(double re)
        {
            Imaginary = 0;
            Real = re;
        }

        public Complex()
        {
            Imaginary = 0;
            Real = 0;
        }

        public static Complex ConstructPolar(double abs, double arg)
        {
            return new Complex(abs * Math.Cos(arg), abs * Math.Sin(arg));
        }

        public static Complex operator -(Complex a)
        {
            return new Complex(-a.Real, -a.Imaginary);
        }
    
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Imaginary * b.Real + b.Imaginary * a.Real);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double re = a.Real * b.Real + a.Imaginary * b.Imaginary;
            re /= Math.Pow(b.Real, 2) + Math.Pow(b.Imaginary, 2);

            double im = b.Real * b.Imaginary - a.Real * a.Imaginary;
            im /= Math.Pow(b.Real, 2) + Math.Pow(b.Imaginary, 2);

            return new Complex(re, im);
        }

        public static bool operator ==(Complex a, Complex b)
        {
            return ((float) a.Real == (float)b.Real) && ((float)a.Imaginary == (float)b.Imaginary);
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !(((float)a.Real == (float)b.Real) && ((float)a.Imaginary == (float)b.Imaginary));
        }

        //public static Complex operator +(double a, Complex c)
        //{
        //    return new Complex(a + c.real, c.imaginary);
        //}


        public static implicit operator Complex(double d)
        {
            return new Complex(d);
        }

        public double Arg()
        {
            return (Math.Atan(Imaginary / Real));
        }

        public double Abs()
        {
            return (Math.Sqrt(Real * Real + Imaginary * Imaginary));
        }

        public Complex Conjugate()
        {
            return new Complex(Real, -Imaginary);
        }

        public override string ToString()
        {
            if (!displayDouble)
            {
                float abs = (float)Abs();
                float ang = (float)Ang();
                float re = (float)Real;
                float im = (float)Imaginary;
                if (stringType == StringType.Rectangular)
                {
                    return String.Format("{0} {1} {2}i", re, (im >= 0) ? '+' : '-', MathF.Abs(im));
                }

                else if (stringType == StringType.RectangularPoint)
                {
                    return String.Format("({0}, {1})", re, im);
                }

                else if (stringType == StringType.Polar)
                {
                    return string.Format("{0}cos({1}) + {0}isin({1}", abs, ang);
                }

                else if (stringType == StringType.PolarPoint)
                {
                    return string.Format("({0}cos({1}), {0}sin({1})", abs, ang);
                }

                else
                {
                    return string.Format("{0}exp({1}i)", abs, ang);
                }
            }

            else
            {
                if (stringType == StringType.Rectangular)
                {
                    return String.Format("{0} {1} {2}i", Real, (Imaginary >= 0) ? '+' : '-', Math.Abs(Imaginary));
                }

                else if (stringType == StringType.RectangularPoint)
                {
                    return String.Format("({0}, {1})", Real, Imaginary);
                }

                else if (stringType == StringType.Polar)
                {
                    return string.Format("{0}cos({1}) + {0}isin({1}", Abs(), Ang());
                }

                else if (stringType == StringType.PolarPoint)
                {
                    return string.Format("({0}cos({1}), {0}sin({1})", Abs(), Ang());
                }

                else
                {
                    return string.Format("{0}exp({1}i)", Abs(), Ang());
                }
            }


        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType()) return false;

            Complex c = (Complex)obj;

            return (c.Real == Real) && (c.Imaginary == Imaginary);
        }

        private double RadToDeg()
        {
            return Arg() * 180 / Math.PI;
        }

        private double Ang()
        {
            return angleUnits == AngleUnits.Deg ? RadToDeg() : Arg();

        }

        public enum StringType
        {
            Rectangular,
            Polar,
            PolarPoint,
            RectangularPoint,
            Exponential
        }

        public enum AngleUnits
        {
            Deg,
            Rad
        }
    }
}
