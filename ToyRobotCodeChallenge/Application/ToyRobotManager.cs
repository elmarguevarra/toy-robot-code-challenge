using System;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;
using ToyRobotCodeChallenge.Services;

namespace ToyRobotCodeChallenge.Application
{
    public class ToyRobotManager : IToyRobotManager
    {
        private const int TOYROBOT_MOVEMENT_UNIT = 1;
        private readonly IToyRobotInputTranslatorService _toyRobotInputTranslatorService;
        private readonly IToyRobotService _toyRobotService;
        private readonly IToyRobotOutputService _toyRobotOutputService;

        public ToyRobotManager(
                    IToyRobotInputTranslatorService toyRobotInputTranslatorService, 
                    IToyRobotService toyRobotService,
                    IToyRobotOutputService toyRobotOutputService)
        {
            _toyRobotInputTranslatorService = toyRobotInputTranslatorService ?? 
                throw new ArgumentNullException(nameof(toyRobotInputTranslatorService));
            _toyRobotService = toyRobotService ??
                throw new ArgumentNullException(nameof(toyRobotService));
            _toyRobotOutputService = toyRobotOutputService ?? 
                throw new ArgumentNullException(nameof(toyRobotOutputService));
        }

        /// <summary>
        /// Orchestrates the system based on the command supplied
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Start()
        {
            var isToyRobotPlacedInTable = false;
            var toyRobotStatus = new ToyRobotStatus();

            while (true)
            {
                try
                {
                    var command = _toyRobotInputTranslatorService.TranslateInputCommand();

                    switch (command.Operation)
                    {
                        case Operation.PLACE:
                            if (command.Arguments.IsCoordinatesValid)
                            {
                                toyRobotStatus = _toyRobotService.PlaceCommand(command.Arguments);
                                isToyRobotPlacedInTable = true;
                            }
                            break;
                        case Operation.MOVE:
                            if (isToyRobotPlacedInTable && toyRobotStatus.IsCoordinatesValid)
                                toyRobotStatus = _toyRobotService.MoveCommand(toyRobotStatus);
                            break;
                        case Operation.LEFT:
                            if (isToyRobotPlacedInTable)
                                toyRobotStatus = _toyRobotService.LeftCommand(toyRobotStatus);
                            break;
                        case Operation.RIGHT:
                            if (isToyRobotPlacedInTable)
                                toyRobotStatus = _toyRobotService.RightCommand(toyRobotStatus);
                            break;
                        case Operation.REPORT:
                            if (isToyRobotPlacedInTable)
                                _toyRobotOutputService.ReportCommand(toyRobotStatus);
                            break;
                    }

                    //NOTE: Based on the examples, REPORT commands seems to terminate the application.
                    // This code is added to mimic the behavior and to terminate the application in test runs.
                    if (command.Operation == Operation.REPORT)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
