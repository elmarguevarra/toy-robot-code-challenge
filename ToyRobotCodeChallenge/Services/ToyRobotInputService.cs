using System;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;

namespace ToyRobotCodeChallenge.Services
{
    public class ToyRobotInputService : IToyRobotInputService
    {
        /// <summary>
        /// Reads input from user from console application.
        /// </summary>
        /// <returns></returns>
        public string ReadInputString()
        {
            return Console.ReadLine();
        }
    }
}
