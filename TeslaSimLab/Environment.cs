using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TeslaSimLab
{
    internal class Environment
    {
        public Environment(int length, int width, int fps = 60) 
        {
            RunTime = new Timer { Enabled = true };
            RunTime.Elapsed += UpdateEnvironment;

            Length = length;
            Width = width;
            Enabled = false;
            FPS = fps;

            Robots = new List<Robot>();
        }

        
        public int Length 
        {
            get {  return Length; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Length must be a positive number!");
                Length = value;
            }
        }
        public int Width 
        {
            get { return Width; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Width must be a positive number!");
                Width = value;
            }
        }
        public int FPS 
        { 
            get { return FPS; }
            set
            {
                if (value == 0) throw new ArgumentOutOfRangeException("FPS must be a positive number!");
                if (Enabled) throw new Exception("Cant change FPS during calculations!");
                RunTime.Interval = 1000 / value;
                FPS = value;
            }
        }
        public bool Enabled { get; set; }
        public List<Robot> Robots;
        public Timer RunTime;


        private void UpdateEnvironment(object sender, ElapsedEventArgs e)
        {
            foreach (Robot robot in Robots) 
            {
                if (robot.Position.X > Width)   robot.TeleportTo(Width, robot.Position.Y);
                if (robot.Position.X < 0)       robot.TeleportTo(0, robot.Position.Y);
                if (robot.Position.Y > Length)  robot.TeleportTo(robot.Position.X, Length);
                if (robot.Position.Y < 0)       robot.TeleportTo(robot.Position.X, 0);
            }


        }



    }
}
