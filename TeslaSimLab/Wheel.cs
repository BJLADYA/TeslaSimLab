using System;

namespace TeslaSimLab
{
    /// <summary>
    /// Содержит физические свойства колеса
    /// </summary>
    internal class Wheel
    {
        public Wheel(double diameter, double motorTorque, double forceAngle = 0)
        {
            Diameter = diameter;
            ForceAngle = forceAngle;
            MotorTorque = motorTorque;
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
        /// Угол движущей силы колеса в радианах.
        /// </summary>
        public double ForceAngle
        { 
            get
            {
                return ForceAngle;
            }
            set
            {
                if (value <= -Math.PI / 2 || value >= Math.PI / 2) 
                    throw new ArgumentOutOfRangeException("Angle range must be in (-PI/2 ; PI/2)");

                ForceAngle = value;
            }
        } 
        /// <summary>
        /// Крутящий момент мотора колеса Н*м.
        /// </summary>
        public double MotorTorque
        { 
            get
            {
                return MotorTorque;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Moment must be positive number");

                MotorTorque = value;
            }
        } 
        /// <summary>
        /// Установленная мощность мотора
        /// </summary>
        public double Power
        {
            get { return Power; }
            set 
            {
                if (value > 1)
                    Power = 1;
                else if (value < -1)
                    Power = -1;
                else
                    Power = value;
            }
        }


        /// <summary>
        /// Вычисляет силу, с которой колесо действует на поверность
        /// </summary>
        /// <returns>Вектор движущей силы</returns>
        public Vector GetForce ()
        {
            return Power != 0 ? new Vector
            {
                X = -Power * 2 * MotorTorque / Diameter * Math.Cos(ForceAngle) * Math.Sin(ForceAngle),
                Y = Power * 2 * MotorTorque / Diameter * Math.Cos(ForceAngle) * Math.Cos(ForceAngle)
            } : new Vector { X = 0, Y = 0 };
        }
    }
}
