using NSubstitute;
using ToyRobotCodeChallenge.Application;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;
using ToyRobotCodeChallenge.Services;
using Xunit;

namespace ToyRobotCodeChallenge.Test
{
    public class AcceptanceTest
    {
        [Fact]
        public void GivenValidInputCommand_ShouldReturnCorrectToyRobotStatus()
        {
            var toyRobotInputServiceMock = Substitute.For<IToyRobotInputService>();
            var toyRobotOutputServiceMock = Substitute.For<IToyRobotOutputService>();

            toyRobotInputServiceMock.ReadInputString()
                .Returns(
                    x => "PLACE 1,2,EAST",
                    x => "MOVE",
                    x => "LEFT",
                    x => "MOVE",
                    x => "RIGHT",
                    x => "MOVE",
                    x => "LEFT",
                    x => "LEFT",
                    x => "MOVE",
                    x => "MOVE",
                    x => "MOVE",
                    x => "RIGHT",
                    x => "REPORT");

            var toyRobotManager = new ToyRobotManager(
                    new ToyRobotInputTranslatorService(toyRobotInputServiceMock),
                    new ToyRobotService(),
                    toyRobotOutputServiceMock);

            toyRobotManager.Start();

            toyRobotOutputServiceMock.Received().ReportCommand(Arg.Is<ToyRobotStatus>(t =>
                    t.FaceDirection == FaceDirection.NORTH &&
                    t.Coordinates.X == 0 &&
                    t.Coordinates.Y == 3));
        }

        [Fact]
        public void GivenValidInputCommand_WithRobotFallingOnMoveCommand_ShouldReturnCorrectToyRobotStatus()
        {
            var toyRobotInputServiceMock = Substitute.For<IToyRobotInputService>();
            var toyRobotOutputServiceMock = Substitute.For<IToyRobotOutputService>();

            toyRobotInputServiceMock.ReadInputString()
                .Returns(
                    x => "PLACE 0,0,SOUTH",
                    x => "MOVE",
                    x => "REPORT");

            var toyRobotManager = new ToyRobotManager(
                    new ToyRobotInputTranslatorService(toyRobotInputServiceMock),
                    new ToyRobotService(),
                    toyRobotOutputServiceMock);

            toyRobotManager.Start();

            toyRobotOutputServiceMock.Received().ReportCommand(Arg.Is<ToyRobotStatus>(t =>
                    t.FaceDirection == FaceDirection.SOUTH &&
                    t.Coordinates.X == 0 &&
                    t.Coordinates.Y == 0));
        }

        [Fact]
        public void GivenValidInputCommand_WithRobotFallingOnPlaceCommand_ShouldReturnCorrectToyRobotStatus()
        {
            var toyRobotInputServiceMock = Substitute.For<IToyRobotInputService>();
            var toyRobotOutputServiceMock = Substitute.For<IToyRobotOutputService>();
            var toyRobotServiceMock = Substitute.For<IToyRobotService>();

            toyRobotInputServiceMock.ReadInputString()
                .Returns(
                    x => "PLACE -1,0,WEST",
                    x => "LEFT",
                    x => "RIGHT",
                    x => "MOVE",
                    x => "REPORT");

            var toyRobotManager = new ToyRobotManager(
                    new ToyRobotInputTranslatorService(toyRobotInputServiceMock),
                    toyRobotServiceMock,
                    toyRobotOutputServiceMock);

            toyRobotManager.Start();

            toyRobotServiceMock.DidNotReceive().LeftCommand(Arg.Any<ToyRobotStatus>());
            toyRobotServiceMock.DidNotReceive().RightCommand(Arg.Any<ToyRobotStatus>());
            toyRobotServiceMock.DidNotReceive().MoveCommand(Arg.Any<ToyRobotStatus>());
            toyRobotOutputServiceMock.DidNotReceive().ReportCommand(Arg.Any<ToyRobotStatus>());
        }

        [Fact]
        public void GivenValidInputCommand_WithRobotNotPlacedInTable_ShouldNotExecuteCommands()
        {
            var toyRobotInputServiceMock = Substitute.For<IToyRobotInputService>();
            var toyRobotOutputServiceMock = Substitute.For<IToyRobotOutputService>();
            var toyRobotServiceMock = Substitute.For<IToyRobotService>();

            toyRobotInputServiceMock.ReadInputString()
                .Returns(
                    x => "LEFT",
                    x => "RIGHT",
                    x => "MOVE",
                    x => "REPORT");

            var toyRobotManager = new ToyRobotManager(
                    new ToyRobotInputTranslatorService(toyRobotInputServiceMock),
                    toyRobotServiceMock,
                    toyRobotOutputServiceMock);

            toyRobotManager.Start();

            toyRobotServiceMock.DidNotReceive().LeftCommand(Arg.Any<ToyRobotStatus>());
            toyRobotServiceMock.DidNotReceive().RightCommand(Arg.Any<ToyRobotStatus>());
            toyRobotServiceMock.DidNotReceive().MoveCommand(Arg.Any<ToyRobotStatus>());
            toyRobotOutputServiceMock.DidNotReceive().ReportCommand(Arg.Any<ToyRobotStatus>());
        }
    }
}
