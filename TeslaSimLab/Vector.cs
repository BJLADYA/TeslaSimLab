using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaSimLab
{
    internal class Vector
    {
        public Vector() 
        {
            X = 0;
            Y = 0;
        }
        public Vector(double x, double y) 
        {
            X = x; 
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Length { get { return Math.Sqrt(X * X + Y * Y); } }
        public double LengthSquared { get { return X * X + Y * Y; } }
        public double CosAlpha { get { return X / Length; } }
        public double CosBeta { get {  return Y / Length; } }

        public static Vector operator +(Vector a, Vector b) 
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static double operator *(Vector a, Vector b) 
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b);
        }

    }
}
