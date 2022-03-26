using System;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;

namespace ToyRobotCodeChallenge.Services
{
    public class ToyRobotOutputService : IToyRobotOutputService
    {
        public void ReportCommand(ToyRobotStatus toyRobotStatus)
        {
            Console.WriteLine("Output: {0},{1},{2}",
                        toyRobotStatus.Coordinates.X,
                        toyRobotStatus.Coordinates.Y,
                        toyRobotStatus.FaceDirection);
        }
    }
}
