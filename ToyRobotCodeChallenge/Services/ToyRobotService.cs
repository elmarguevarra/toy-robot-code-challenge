using System;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;

namespace ToyRobotCodeChallenge.Services
{
    public class ToyRobotService : IToyRobotService
    {
        private const int TOYROBOT_MOVEMENT_UNIT = 1;

        #region Main methods

        public ToyRobotStatus PlaceCommand(ToyRobotStatus commandArguments)
        {
            return commandArguments;
        }

        //NOTE: NORTH and SOUTH displacements are reversed due to requirement that origin (0,0) is to be the SOUTH WEST most corner.
        public ToyRobotStatus MoveCommand(ToyRobotStatus toyRobotStatus)
        {
            var newToyRobotStatus = new ToyRobotStatus();
            switch (toyRobotStatus.FaceDirection)
            {
                case FaceDirection.SOUTH: //FaceDirection.NORTH:
                    newToyRobotStatus = new ToyRobotStatus(
                        new Coordinates(toyRobotStatus.Coordinates.X, toyRobotStatus.Coordinates.Y - TOYROBOT_MOVEMENT_UNIT),
                        toyRobotStatus.FaceDirection);
                    break;
                case FaceDirection.EAST:
                    newToyRobotStatus = new ToyRobotStatus(
                        new Coordinates(toyRobotStatus.Coordinates.X + TOYROBOT_MOVEMENT_UNIT, toyRobotStatus.Coordinates.Y),
                        toyRobotStatus.FaceDirection);
                    break;
                case FaceDirection.NORTH: //FaceDirection.SOUTH:
                    newToyRobotStatus = new ToyRobotStatus(
                        new Coordinates(toyRobotStatus.Coordinates.X, toyRobotStatus.Coordinates.Y + TOYROBOT_MOVEMENT_UNIT),
                        toyRobotStatus.FaceDirection);
                    break;
                case FaceDirection.WEST:
                    newToyRobotStatus = new ToyRobotStatus(
                        new Coordinates(toyRobotStatus.Coordinates.X - TOYROBOT_MOVEMENT_UNIT, toyRobotStatus.Coordinates.Y),
                        toyRobotStatus.FaceDirection);
                    break;
                default:
                    return toyRobotStatus;
            }
            return newToyRobotStatus.IsCoordinatesValid ? newToyRobotStatus : toyRobotStatus;
        }

        public ToyRobotStatus LeftCommand(ToyRobotStatus toyRobotStatus)
        {
            var newFaceDirection = determineNewFaceDirection(Side.LEFT, toyRobotStatus.FaceDirection);
            return new ToyRobotStatus(toyRobotStatus.Coordinates, newFaceDirection);
        }

        public ToyRobotStatus RightCommand(ToyRobotStatus toyRobotStatus)
        {
            var newFaceDirection = determineNewFaceDirection(Side.RIGHT, toyRobotStatus.FaceDirection);
            return new ToyRobotStatus(toyRobotStatus.Coordinates, newFaceDirection);
        }

        #endregion Main methods

        #region Helper methods

        private FaceDirection determineNewFaceDirection(Side side, FaceDirection faceDirection)
        {
            var direction = (int)faceDirection + (int)side;

            if (direction < 0)
                return (FaceDirection)3;
            else if (direction > 3)
                return 0;

            return (FaceDirection)direction;
        }

        #endregion Helper methods
    }
}
