using Microsoft.Extensions.DependencyInjection;
using ToyRobotCodeChallenge.Application;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Services;

namespace ToyRobotCodeChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IToyRobotManager, ToyRobotManager>()
                .AddSingleton<IToyRobotService, ToyRobotService>()
                .AddSingleton<IToyRobotInputService, ToyRobotInputService>()
                .AddSingleton<IToyRobotInputTranslatorService, ToyRobotInputTranslatorService>()
                .AddSingleton<IToyRobotOutputService, ToyRobotOutputService>()
                .BuildServiceProvider();

            var toyRobot = serviceProvider.GetService<IToyRobotManager>();
            toyRobot.Start();
        }
    }
}
