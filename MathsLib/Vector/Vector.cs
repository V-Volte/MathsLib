using System;
using System.Collections.Generic;
using System.Text;

namespace MathsLib
{
    class IncompatibleVectorsException : Exception
    {
        public override string Message => "Incompatible vectors";
    }
    class Vector
    {
        private double[] array;
        public int Dimension { get; protected set; }

        public Vector(int dimension)
        {
            array = new double[dimension];
            Dimension = dimension;
        }

        public Vector(double[] a)
        {
            array = a;
            Dimension = a.Length;
        }

        public double this[int i]
        {
            get => array[i];
            set => array[i] = value;
        }

        public static Vector operator+ (Vector a, Vector b)
        {
            if (a.Dimension != b.Dimension)
            {
                throw new IncompatibleVectorsException();
            }

            Vector c = new Vector(a.array);

            for (int i = 0; i < a.Dimension; ++i)
            {
                c[i] += b[i];
            }

            return c;
        }


        public static double operator *(Vector a, Vector b)
        {
            if (a.Dimension != b.Dimension)
            {
                throw new IncompatibleVectorsException();
            }

            Vector c = new Vector(a.array);

            for (int i = 0; i < a.Dimension; ++i)
            {
                c[i] *= b[i];
            }

            return c.Sum();
        }

        public static Vector operator -(Vector a, Vector b)
        {
            if (a.Dimension != b.Dimension)
            {
                throw new IncompatibleVectorsException();
            }

            Vector c = new Vector(a.array);

            for (int i = 0; i < a.Dimension; ++i)
            {
                c[i] -= b[i];
            }

            return c;
        }

        public static Vector operator *(Vector a, int b)
        {

            Vector c = new Vector(a.array);

            for (int i = 0; i < a.Dimension; ++i)
            {
                c[i] *= b;
            }

            return c;
        }

        public static Vector operator /(Vector a, int b)
        {

            Vector c = new Vector(a.array);

            for (int i = 0; i < a.Dimension; ++i)
            {
                c[i] /= b;
            }

            return c;
        }

        public double Sum()
        {
            double sum = 0;

            foreach (double v in array)
            {
                sum += v;
            }

            return sum;
        }

        public double Magnitude()
        {
            double magnitude = 0;

            foreach(var v in array)
            {
                magnitude += v * v;
            }

            return Math.Sqrt(magnitude);
        }

    }

}
