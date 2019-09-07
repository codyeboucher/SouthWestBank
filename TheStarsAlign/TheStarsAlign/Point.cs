using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStarsAlign
{
    public class Point
    {   
        public int X_Position { get; set; }

        public int Y_Position { get; set; }

        public int X_Velocity { get; set; }

        public int Y_Velocity { get; set; }

        public void FastForward()
        {
            X_Position += X_Velocity;
            Y_Position += Y_Velocity;
        }

        public bool pointExists(int x, int y)
        {
            return X_Position == x && Y_Position == y;
        }
    }
}
