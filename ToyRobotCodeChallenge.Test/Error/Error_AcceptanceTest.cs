using NSubstitute;
using System;
using System.IO;
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
                .Returns(
                    x => "place 1,2,east",
                    x => "REPORT");

            var toyRobotManager = new ToyRobotManager(
                    new ToyRobotInputTranslatorService(toyRobotInputServiceMock), 
                    new ToyRobotService(),
                    toyRobotOutputServiceMock);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            toyRobotManager.Start();
            Assert.Contains("Invalid command", stringWriter.ToString());
        }
    }
}
