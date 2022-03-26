using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotCodeChallenge.Models
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;

            //Validate
        }

        public int X { get; }
        public int Y { get; }
    }
}
