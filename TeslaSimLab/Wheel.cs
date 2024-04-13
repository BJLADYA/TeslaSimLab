using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaSimLabExtensions;

namespace TeslaSimLab
{
    /// <summary>
    /// Содержит физические свойства колеса.
    /// </summary>
    internal class Wheel
    {
        public Wheel(double diameter, double motorMoment, double forceAngle = 0)
        {
            Diameter = diameter;
            ForceAngle = forceAngle;
            MotorMoment = motorMoment;
        }

        /// <summary>
        /// Диаметр колеса. 
        /// Задается в мм, хранится в м.
        /// </summary>
        public double Diameter
        { 
            get
            {
                return Diameter;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Diameter must be a positive number");

                Diameter = value / 1000;
            }
        } 

        /// <summary>
        /// Угол движущей силы колеса.
        /// Задается в градусах, хранится в радианах.
        /// </summary>
        public double ForceAngle
        { 
            get
            {
                return ForceAngle;
            }
            set
            {
                if (value <= -90)
                    throw new ArgumentOutOfRangeException("Angle range must be in [-90;90]");

                ForceAngle = value.ToRadians();
            }
        } 

        /// <summary>
        /// Крутящий момент мотора колеса Н*м.
        /// </summary>
        public double MotorMoment
        { 
            get
            {
                return MotorMoment;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Moment must be positive number");

                MotorMoment = value;
            }
        } 

        public Vector GetForce (double power)
        {
            if (power > 1)
                power = 1;
            else if (power < -1)
                power = -1;

            return new Vector
            {
                X = -power * 2 * MotorMoment / Diameter * Math.Cos(ForceAngle) * Math.Sin(ForceAngle),
                Y = power * 2 * MotorMoment / Diameter * Math.Cos(ForceAngle) * Math.Cos(ForceAngle)
            };
        }
    }
}
