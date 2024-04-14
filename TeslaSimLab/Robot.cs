using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TeslaSimLab
{
    /// <summary>
    /// Класс робота
    /// </summary>
    internal class Robot
    {
        private Robot(int length, int width, double mass) 
        {
            Length = length;
            Width = width;
            Mass = mass;

            Velocity = new Vector { X = 0, Y = 0 };
            Acceleration = new Vector { X = 0, Y = 0 };
            AngularSpeed = 0;
            AngularAcceleration = 0;
            Position = new Vector { X = 0, Y = 0 };
            Heading = 0;

            Config = new RobotConfig();
        }
        public Robot(int length, int width, double mass, Wheel[] wheels) : this(length, width, mass)
        {
            if (wheels.Length != 4)
                throw new ArgumentException("Robot must has 4 wheels!");
            Wheels = wheels;
        }
        public Robot(int length, int width, double mass, Wheel refwheel) : this(length, width, mass)
        {
            if (refwheel == null)
                throw new ArgumentNullException("Argument is null!");

            Wheels = new Wheel[4]
            {
                new Wheel(refwheel.Diameter, refwheel.MotorTorque, refwheel.ForceAngle < 0 ? refwheel.ForceAngle : -refwheel.ForceAngle),
                new Wheel(refwheel.Diameter, refwheel.MotorTorque, refwheel.ForceAngle > 0 ? refwheel.ForceAngle : -refwheel.ForceAngle),
                new Wheel(refwheel.Diameter, refwheel.MotorTorque, refwheel.ForceAngle < 0 ? refwheel.ForceAngle : -refwheel.ForceAngle),
                new Wheel(refwheel.Diameter, refwheel.MotorTorque, refwheel.ForceAngle > 0 ? refwheel.ForceAngle : -refwheel.ForceAngle),
            };
        }


        /// <summary>
        /// Массоразмерные характеристики робота
        /// </summary>
        public double Length 
        {
            get { return Length; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Length must be positive!");
                Length = value / 1000;
            }
        }
        public double Width 
        { 
            get { return Width; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Width must be positive number!");
                Width = value / 1000;
            }
        }
        public double Mass 
                {
                    get { return Mass; }
                    private set
                    {
                        if (value < 0)
                            throw new ArgumentException("Mass must be positive number!");
                        Mass = value;
                    }
                }

        /// <summary>
        /// Кинематические характеристики робота
        /// </summary>
        public Vector Velocity { get; private set; }
        public Vector Acceleration { get; private set; }
        public double AngularSpeed { get; private set; }
        public double AngularAcceleration { get; private set; }
        public Vector Position { get; private set; }
        public double Heading { get; private set; }
        public Vector InnerForce 
        { 
            get
            {
                Vector force = new Vector();

                foreach (var wheel in Wheels)
                {
                    force += wheel.GetForce();
                }

                return force;
            }
        }
        public double InnerTorque 
        { 
            get
            {
                double torque = 0;

                for (int i = 0, j = 1; i < Wheels.Length; i++, j++) 
                {
                    torque += Wheels[i].GetForce().Y * Width / 2 * Math.Pow(-1, j);
                    torque += Wheels[i].GetForce().X * Length / 2 * -1;
                }

                return torque;
            }
        }

        /// <summary>
        /// Программные характеристики
        /// </summary>
        public RobotConfig Config { get; set; }

        /// <summary>
        /// Структурные характеристики робота
        /// </summary>
        private Wheel[] Wheels;


        /// <summary>
        /// Телепортирует робота в указанные координаты
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void TeleportTo(double x, double y)
        {
            Position.X = x;
            Position.Y = y;
        }

        /// <summary>
        /// Устанавливает мощность на выбранном моторе
        /// </summary>
        /// <param name="wheelname">Название мотора в конфигурации робота</param>
        /// <param name="power">Устанавливаемая мощность</param>
        public void SetPower(string wheelname, double power)
        {
            Wheels[Config.Wheel(wheelname)].Power = power;
        }

    }
}
