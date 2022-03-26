using ToyRobotCodeChallenge.Models;

namespace ToyRobotCodeChallenge.Interfaces
{
    public interface IToyRobotOutputService
    {
        void ReportCommand(ToyRobotStatus toyRobotStatus);
    }
}