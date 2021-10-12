using System;


namespace MathsLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex.stringType = Complex.StringType.Rectangular;

            Complex a = new Complex(1, 1);
            Complex b = new Complex(3, 5);

            Complex c = new Complex();
            c = Complex.ConstructPolar(Math.Sqrt(2), Math.PI / 4);

            Console.WriteLine("a * b is " + a * b);
            Console.WriteLine("2a - 3b is " + (2 * a - 3 * b));

            Complex.stringType = Complex.StringType.PolarPoint;
            Console.WriteLine("a is " + a + ", b is " + b + ", c is " + c);

            Complex.stringType = Complex.StringType.Exponential;

            Console.WriteLine("a is "+  a + ", b is " + b);

            Console.WriteLine("a == c is " + (a == c));

            Console.WriteLine(Math.Sqrt(2));

        }
    }
}
