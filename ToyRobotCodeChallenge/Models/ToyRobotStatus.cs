using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotCodeChallenge.Models.Enums;

namespace ToyRobotCodeChallenge.Models
{
    public class ToyRobotStatus //Interface or baseclass for all the commands ? for extension of commands
    {
        private const int minimumCoordinateValue = 0;
        private const int maximumCoordinateValue = 4;

        private readonly Coordinates _coordinates;
        private readonly FaceDirection _faceDirection;

        public ToyRobotStatus()
        {
            _coordinates = new Coordinates(0, 0);
            _faceDirection = default;
        }
        public ToyRobotStatus(Coordinates coordinates, FaceDirection faceDirection)
        {
            _coordinates = coordinates;
            _faceDirection = faceDirection;
        }

        public Coordinates Coordinates { get { return _coordinates; } }
        public FaceDirection FaceDirection { get { return _faceDirection; } }
        public bool IsCoordinatesValid => 
           (_coordinates.X >= minimumCoordinateValue &&
            _coordinates.Y >= minimumCoordinateValue &&
            _coordinates.X <= maximumCoordinateValue &&
            _coordinates.Y <= maximumCoordinateValue);
    }
}
