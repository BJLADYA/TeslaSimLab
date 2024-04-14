using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaSimLabExtensions
{
    internal static class Extensions
    {
        /// <summary>
        /// Переводит градусы в радианы
        /// </summary>
        /// <param name="value"> Угол в градусах </param>
        /// <returns> Радианы </returns>
        public static double ToRadians(this double value)
        {
            return value * Math.PI / 180;
        }
    }
}
