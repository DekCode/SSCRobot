using SSCRobot.Common.Enums;
using SSCRobot.Common.Models;
using System.Drawing;

namespace SSCRobot.Services.Tests;

public class RobotPlacementServiceTests
{
    private readonly Board _board = new Board(5, 5);
    private readonly RobotPlacementService _service = new();

    [Theory]
    [InlineData(0, 4, DirectionType.South)]
    [InlineData(4, 0, DirectionType.West)]
    [InlineData(4, 4, DirectionType.North)]
    [InlineData(4, 0, DirectionType.East)]
    public void PlaceRobot_WhenPositionIsValid_ReturnsNewRobot(int x, int y, DirectionType direction)
    {
        // Arrange
        var command = new PlaceCommand
        {
            FacingDirection = direction,
            Position = new Point(x, y),
        };

        // Act
        var actual = _service.PlaceRobot(command, _board);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(x, actual.Position.X);
        Assert.Equal(y, actual.Position.Y);
        Assert.Equal(direction, actual.FacingDirection);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(-1, 0)]
    [InlineData(-1, -1)]
    [InlineData(100, 0)]
    public void PlaceRobot_WhenPositionIsInvalid_ReturnsNull(int x, int y)
    {
        // Arrange
        var command = new PlaceCommand
        {
            FacingDirection = DirectionType.North,
            Position = new Point(x, y),
        };

        // Act
        var actual = _service.PlaceRobot(command, _board);

        // Assert
        Assert.Null(actual);
    }
}
