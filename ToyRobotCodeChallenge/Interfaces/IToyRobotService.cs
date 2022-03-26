using ToyRobotCodeChallenge.Models;

namespace ToyRobotCodeChallenge.Interfaces
{
    public interface IToyRobotService
    {
        ToyRobotStatus LeftCommand(ToyRobotStatus toyRobotStatus);
        ToyRobotStatus MoveCommand(ToyRobotStatus toyRobotStatus);
        ToyRobotStatus PlaceCommand(ToyRobotStatus commandArguments);
        ToyRobotStatus RightCommand(ToyRobotStatus toyRobotStatus);
    }
}