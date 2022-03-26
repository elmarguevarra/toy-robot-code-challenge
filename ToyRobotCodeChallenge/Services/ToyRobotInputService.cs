using System;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;

namespace ToyRobotCodeChallenge.Services
{
    public class ToyRobotInputService : IToyRobotInputService
    {
        public string ReadInputString()
        {
            return Console.ReadLine();
        }
    }
}
