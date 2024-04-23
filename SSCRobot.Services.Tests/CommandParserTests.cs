using SSCRobot.Common.Enums;
using SSCRobot.Common.Models;

namespace SSCRobot.Services.Tests;

public class CommandParserTests
{
    [Theory]
    [InlineData("test")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("123456")]
    public void Parse_WhenCommandIsInvalid_ReturnsNull(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("MOVE")]
    [InlineData("move")]
    [InlineData("Move")]
    [InlineData("mOvE")]
    public void Parse_WhenInputCaseInsensitiveMove_ReturnsMoveCommand(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal("MOVE", actual.Name);
    }

    [Theory]
    [InlineData("LEFT")]
    [InlineData("left")]
    [InlineData("Left")]
    [InlineData("lEfT")]
    public void Parse_WhenInputCaseInsensitiveLeft_ReturnsLeftCommand(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal("LEFT", actual.Name);
    }

    [Theory]
    [InlineData("RIGHT")]
    [InlineData("right")]
    [InlineData("Right")]
    [InlineData("rIgHt")]
    public void Parse_WhenInputCaseInsensitiveRight_ReturnsRightCommand(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal("RIGHT", actual.Name);
    }

    [Theory]
    [InlineData("REPORT")]
    [InlineData("report")]
    [InlineData("Report")]
    public void Parse_WhenInputCaseInsensitiveReport_ReturnsReportCommand(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal("REPORT", actual.Name);
    }

    [Theory]
    [InlineData("PLACE 1,2,NORTH")]
    [InlineData("PLACE -1,-2,NORTH")]
    [InlineData("PLACE 0,0,NORTH")]
    [InlineData("place 2,2,north")]
    public void Parse_WhenInputCaseInsensitivePlace_ReturnsPlaceCommand(string input)
    {
        // Arrange
        var coordinates = input.Split(' ')[1].Split(',');
        var expectedX = int.Parse(coordinates[0]);
        var expectedY = int.Parse(coordinates[1]);
        var direction = Enum.Parse<DirectionType>(coordinates[2], true);

        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.NotNull(actual);
        Assert.IsAssignableFrom<IPlaceCommand>(actual);

        var placeCommand = actual as IPlaceCommand;
        Assert.NotNull(placeCommand);

        Assert.Equal("PLACE", placeCommand.Name);
        Assert.Equal(expectedX, placeCommand.Position.X);
        Assert.Equal(expectedY, placeCommand.Position.Y);
        Assert.Equal(direction, placeCommand.FacingDirection);
    }

    [Theory]
    [InlineData("PLACE x,2,NORTH")]
    [InlineData("PLACE 1,y,NORTH")]
    [InlineData("PLACE -1,-2,N")]
    public void Parse_WhenInputPlaceWithInvalidDataType_ReturnsNull(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("PLACE 1")]
    [InlineData("PLACE 1,2,")]
    [InlineData("PLACE 1,,NORTH")]
    public void Parse_WhenInputPlaceWithInvalidFormat_ReturnsNull(string input)
    {
        // Arrange
        // Act
        var actual = CommandParser.Parse(input);

        // Assert
        Assert.Null(actual);
    }
}
