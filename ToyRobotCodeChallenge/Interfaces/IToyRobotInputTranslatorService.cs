using ToyRobotCodeChallenge.Models;

namespace ToyRobotCodeChallenge.Interfaces
{
    public interface IToyRobotInputTranslatorService
    {
        Command TranslateInputCommand();
    }
}