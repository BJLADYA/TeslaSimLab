using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaSimLab
{
    /// <summary>
    /// Предназначен для организации программной конфигурации имен приводов робота
    /// </summary>
    internal class RobotConfig
    {
        public RobotConfig() 
        {
            WheelsConfig = new Dictionary<string, int>
            {
                { "LeftFront", 0 },
                { "RightFront", 1 },
                { "LeftBack", 2 },
                { "RightBack", 3 }
            };
        }

        /// <summary>
        /// Название колеса -> Индекс колеса
        /// </summary>
        public Dictionary<string, int> WheelsConfig 
        { 
            private get { return WheelsConfig; }
            set { WheelsConfig = value; }
        }

        public int Wheel(string name) { return WheelsConfig[name]; }
    }
}
