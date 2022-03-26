using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;

namespace ToyRobotCodeChallenge.Services
{
    public class ToyRobotInputTranslatorService : IToyRobotInputTranslatorService
    {
        private readonly IToyRobotInputService _toyRobotInputService;

        public ToyRobotInputTranslatorService(IToyRobotInputService toyRobotInputService)
        {
            _toyRobotInputService = toyRobotInputService ??
                throw new ArgumentNullException(nameof(toyRobotInputService));
        }
        public Command TranslateInputCommand()
        {
            try
            {
                var commandArguments = new ToyRobotStatus();
                var command = _toyRobotInputService.ReadInputString();

                var operation = Enum.Parse<Operation>(command.Split(' ')[0]);

                if (operation == Operation.PLACE)
                {
                    var coordinates =
                        new Coordinates(
                                int.Parse(command.Split(' ')[1].Split(',')[0]),
                                int.Parse(command.Split(' ')[1].Split(',')[1]));

                    var faceDirection = Enum.Parse<FaceDirection>(command.Split(' ')[1].Split(',')[2]);

                    commandArguments = new ToyRobotStatus(coordinates, faceDirection);
                }

                return new Command(operation, commandArguments);
            }
            catch (Exception)
            {
                throw new Exception("Invalid command");
            }
        }
    }
}
