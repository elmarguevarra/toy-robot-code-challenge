using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotCodeChallenge.Models.Enums;

namespace ToyRobotCodeChallenge.Models
{
    public class Command
    {
        public Command(Operation operation, ToyRobotStatus arguments)
        {
            Operation = operation;
            Arguments = arguments;
        }

        public Operation Operation { get; }
        public ToyRobotStatus Arguments { get; }
    }
}
