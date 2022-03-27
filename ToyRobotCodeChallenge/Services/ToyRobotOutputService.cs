using System;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;

namespace ToyRobotCodeChallenge.Services
{
    public class ToyRobotOutputService : IToyRobotOutputService
    {
        /// <summary>
        /// Outputs the coordinates and current direction toy robot is facing using console application.
        /// </summary>
        /// <param name="toyRobotStatus"></param>
        public void ReportCommand(ToyRobotStatus toyRobotStatus)
        {
            Console.WriteLine("Output: {0},{1},{2}",
                        toyRobotStatus.Coordinates.X,
                        toyRobotStatus.Coordinates.Y,
                        toyRobotStatus.FaceDirection);
        }
    }
}
