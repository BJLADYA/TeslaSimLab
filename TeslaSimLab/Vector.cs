using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaSimLabExtensions;

namespace TeslaSimLab
{
    internal struct Vector
    {
        public Vector(double x, double y) 
        {
            X = x; 
            Y = y;
        }
        public Vector(Vector other)
        {
            X = other.X;
            Y = other.Y;
        }


        public double X;
        public double Y;
        public double Length { get { return Math.Sqrt(X * X + Y * Y); } }
        public double LengthSquared { get { return X * X + Y * Y; } }
        /// <summary>
        /// Направляющий косинус оси Х
        /// </summary>
        public double CosAlpha { get { return X / Length; } }
        /// <summary>
        /// Направяющий косинус оси У
        /// </summary>
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


        /// <summary>
        /// НЕ изменяет сам себя, возвращает свою повернутую копию
        /// </summary>
        /// <param name="angle">Угол поворота в радианах</param>
        /// <returns> Повернутый вектор </returns>
        public Vector TurnBy(double angle)
        {
            return new Vector
                (
                X * Math.Cos(angle) - Y * Math.Sin(angle), 
                X * Math.Sin(angle) + Y * Math.Cos(angle)
                );
        }

    }
}
