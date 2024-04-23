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
        private readonly IInputProvider _inputProvider;
        private readonly IOutputProvider _outputProvider;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inputProvider"></param>
        /// <param name="outputProvider"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RobotRunner(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            _inputProvider = inputProvider ?? throw new ArgumentNullException(nameof(inputProvider));
            _outputProvider = outputProvider ?? throw new ArgumentNullException(nameof(outputProvider));
        }

        /// <summary>
        /// Runs the robot app
        /// </summary>
        /// <param name="inputProvider"></param>
        /// <param name="outputProvider"></param>
        public void Run()
        {
            while (true)
            {
                // Read from user input
                var userInput = _inputProvider.Read();
                // Just to quit the app
                if (userInput != null && userInput.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }

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

            _outputProvider.Write($"Output: {_robot.Position.X} {_robot.Position.Y} {_robot.FacingDirection.ToString().ToUpperInvariant()}");
        }
    }
}
