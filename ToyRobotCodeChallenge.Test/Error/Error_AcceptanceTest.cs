using NSubstitute;
using System;
using ToyRobotCodeChallenge.Application;
using ToyRobotCodeChallenge.Interfaces;
using ToyRobotCodeChallenge.Models;
using ToyRobotCodeChallenge.Models.Enums;
using ToyRobotCodeChallenge.Services;
using Xunit;

namespace ToyRobotCodeChallenge.Test.Error
{
    public class Error_AcceptanceTest
    {
        [Fact]
        public void GivenInvalidInputCommand_ShouldThrowException()
        {
            var toyRobotInputServiceMock = Substitute.For<IToyRobotInputService>();
            var toyRobotOutputServiceMock = Substitute.For<IToyRobotOutputService>();

            toyRobotInputServiceMock.ReadInputString()
                .Returns("place 1,2,east");

            var toyRobotManager = new ToyRobotManager(
                    new ToyRobotInputTranslatorService(toyRobotInputServiceMock), 
                    new ToyRobotService(),
                    toyRobotOutputServiceMock);

            Assert.Throws<Exception>(() => toyRobotManager.Start());
        }
    }
}
