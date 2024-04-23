using SSCRobot.Common.Constants;
using SSCRobot.Common.Helpers;
using SSCRobot.Common.Models;
using SSCRobot.Services;

namespace SSCRobot
{
    /// <summary>
    /// The robot runner
    /// </summary>
    public class RobotRunner
    {
        private const int BoardWidth = 5;
        private const int BoardHeight = 5;
        private readonly Board _board = new(BoardWidth, BoardHeight);
        private Robot? _robot;

        private readonly RobotMovementService _movementService = new();
        private readonly RobotPlacementService _placementService = new();

        public void Run()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                // Ignore anything except for the PLACE command if we haven't placed the robot
                if (_robot == null)
                {
                    TryPlaceRobot(userInput);
                }
                // Consider anything but the PLACE command
                else
                {
                    var command = CommandParser.Parse(userInput);
                    // Ignore invalid command and a place command
                    if (command == null || command is IPlaceCommand)
                    {
                        continue;
                    }

                    if (command.Name == CommandDefaults.Move)
                    {
                        _movementService.Move(_robot, _board);
                    }
                    else if (command.Name == CommandDefaults.Left)
                    {
                        _movementService.TurnLeft(_robot);
                    }
                    else if (command.Name == CommandDefaults.Right)
                    {
                        _movementService.TurnRight(_robot);
                    }
                    else if (command.Name == CommandDefaults.Report)
                    {
                        // TODO: output
                        DisplayRobotPosition();
                    }
                }
            }
        }

        private void TryPlaceRobot(string? userInput)
        {
            // If it's the PLACE command, we try place the robot on the board if the position is valid.
            var placeCommand = CommandParser.Parse(userInput) as IPlaceCommand;
            if (placeCommand == null || !_board.IsOnBoard(placeCommand.Position))
            {
                return;
            }

            // Try place a robot
            _robot = _placementService.PlaceRobot(placeCommand, _board);
        }

        private void DisplayRobotPosition()
        {
            if (_robot == null)
            {
                return;
            }

            Console.WriteLine($"{_robot.Position.X} {_robot.Position.Y} {_robot.FacingDirection.ToString().ToUpperInvariant()}");
        }
    }
}
