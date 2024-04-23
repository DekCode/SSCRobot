using Moq;

namespace SSCRobot.Tests
{
    public class RobotRunnerTests
    {
        [Fact]
        public void Run_WhenOperationIsSuccessful_RobotCorrectlyRoams()
        {
            // Arrange
            var mockInputProvider = new Mock<IInputProvider>();
            var mockOutputProvider = new Mock<IOutputProvider>();

            mockInputProvider.SetupSequence(x => x.Read())
                // Place a robot
                .Returns("PLACE 0,0,EAST")
                // Move
                .Returns("MOVE")
                .Returns("REPORT")

                // Face the edge then move
                .Returns("RIGHT")
                .Returns("MOVE")
                .Returns("REPORT")

                // Face away from the edge by rotating back then move
                .Returns("LEFT")
                .Returns("REPORT")

                .Returns("LEFT")
                .Returns("REPORT")

                .Returns("MOVE")
                .Returns("REPORT")

                .Returns("MOVE")
                .Returns("REPORT")

                .Returns("q");

            var demo = new RobotRunner(mockInputProvider.Object, mockOutputProvider.Object);

            // Act
            demo.Run();

            // Assert
            mockOutputProvider.Verify(x => x.Write("1 0 EAST"), Times.Exactly(2));
            mockOutputProvider.Verify(x => x.Write("1 0 SOUTH"), Times.Once);
            mockOutputProvider.Verify(x => x.Write("1 0 NORTH"), Times.Once);
            mockOutputProvider.Verify(x => x.Write("1 1 NORTH"), Times.Once);
            mockOutputProvider.Verify(x => x.Write("1 2 NORTH"), Times.Once);
        }

        [Fact]
        public void Run_WhenRobotIsNotPlaced_IgnoreMovementCommands()
        {
            // Arrange
            var mockInputProvider = new Mock<IInputProvider>();
            var mockOutputProvider = new Mock<IOutputProvider>();

            mockInputProvider.SetupSequence(x => x.Read())
                // Move
                .Returns("MOVE")
                .Returns("REPORT")

                // Face the edge then move
                .Returns("RIGHT")
                .Returns("MOVE")
                .Returns("REPORT")

                // Face away from the edge by rotating back then move
                .Returns("LEFT")
                .Returns("REPORT")

                .Returns("LEFT")
                .Returns("REPORT")

                .Returns("MOVE")
                .Returns("REPORT")

                .Returns("MOVE")
                .Returns("REPORT")

                .Returns("q");

            var demo = new RobotRunner(mockInputProvider.Object, mockOutputProvider.Object);

            // Act
            demo.Run();

            // Assert
            mockOutputProvider.Verify(x => x.Write(It.IsAny<string>()), Times.Never);
        }
    }
}