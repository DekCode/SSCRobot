using SSCRobot.Common.Enums;
using SSCRobot.Common.Models;
using System.Drawing;

namespace SSCRobot.Services.Tests;

public class RobotMovementServiceTests
{
    private readonly Board _board = new Board(5, 5);
    private readonly RobotMovementService _movementService = new();

    [Theory]
    [InlineData(0, 0, DirectionType.North, 0, 1)]
    [InlineData(0, 0, DirectionType.East, 1, 0)]
    [InlineData(0, 1, DirectionType.South, 0, 0)]
    [InlineData(1, 0, DirectionType.West, 0, 0)]
    public void Move_WhenDirectionNotAgainstEdge_MovesOneUnitTowardFacingDirection(int x, int y, DirectionType direction, int expectedX, int expectedY)
    {
        // Arrange
        var robot = new Robot
        {
            FacingDirection = direction,
            Position = new Point(x, y),
        };

        // Act
        _movementService.Move(robot, _board);

        // Assert
        Assert.Equal(expectedX, robot.Position.X);
        Assert.Equal(expectedY, robot.Position.Y);
        Assert.Equal(direction, robot.FacingDirection);
    }

    [Theory]
    [InlineData(0, 0, DirectionType.South)]
    [InlineData(0, 0, DirectionType.West)]
    [InlineData(4, 4, DirectionType.North)]
    [InlineData(4, 4, DirectionType.East)]
    public void Move_WhenDirectionAgainstEdge_DoesNotMove(int x, int y, DirectionType direction)
    {
        // Arrange
        var robot = new Robot
        {
            FacingDirection = direction,
            Position = new Point(x, y),
        };

        // Act
        _movementService.Move(robot, _board);

        // Assert
        Assert.Equal(x, robot.Position.X);
        Assert.Equal(y, robot.Position.Y);
        Assert.Equal(direction, robot.FacingDirection);
    }

    [Theory]
    [InlineData(DirectionType.East, DirectionType.South)]
    [InlineData(DirectionType.South, DirectionType.West)]
    [InlineData(DirectionType.West, DirectionType.North)]
    [InlineData(DirectionType.North, DirectionType.East)]
    public void TurnRight_WhenOperationIsSuccessful_TurnToNextClockwiseDirection(DirectionType direction, DirectionType expected)
    {
        // Arrange
        var robot = new Robot
        {
            FacingDirection = direction,
            Position = new Point(1, 1),
        };

        // Act
        _movementService.TurnRight(robot);

        // Assert
        Assert.Equal(1, robot.Position.X);
        Assert.Equal(1, robot.Position.Y);
        Assert.Equal(expected, robot.FacingDirection);
    }

    [Theory]
    [InlineData(DirectionType.East, DirectionType.North)]
    [InlineData(DirectionType.South, DirectionType.East)]
    [InlineData(DirectionType.West, DirectionType.South)]
    [InlineData(DirectionType.North, DirectionType.West)]
    public void TurnLeft_WhenOperationIsSuccessful_TurnToNextCounterClockwiseDirection(DirectionType direction, DirectionType expected)
    {
        // Arrange
        var robot = new Robot
        {
            FacingDirection = direction,
            Position = new Point(1, 1),
        };

        // Act
        _movementService.TurnLeft(robot);

        // Assert
        Assert.Equal(1, robot.Position.X);
        Assert.Equal(1, robot.Position.Y);
        Assert.Equal(expected, robot.FacingDirection);
    }
}
