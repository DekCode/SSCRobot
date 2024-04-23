using SSCRobot.Common.Constants;
using SSCRobot.Common.Enums;
using SSCRobot.Common.Models;
using ICommand = SSCRobot.Common.Models.ICommand;

namespace SSCRobot.Services
{
    /// <summary>
    /// The robot case-insensitive command parser
    /// </summary>
    public static class CommandParser
    {
        private static readonly IEnumerable<string> ArgumentlessCommands =
        [
            CommandDefaults.Move,
            CommandDefaults.Left,
            CommandDefaults.Right,
            CommandDefaults.Report,
        ];

        /// <summary>
        /// Parses a command.
        /// <para>PLACE 1,2,NORTH</para>
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns>An implementation of <see cref="ICommand"/> or <see langword="null"/> if invalid</returns>
        public static ICommand? Parse(string? commandString)
        {
            if (string.IsNullOrWhiteSpace(commandString))
            {
                return null;
            }

            var capitalizedInput = commandString.ToUpperInvariant();
            // Return a simple command if valid
            if (ArgumentlessCommands.Contains(capitalizedInput))
            {
                return new Command
                {
                    Name = capitalizedInput,
                };
            }

            // Parse a place command if it starts with 'place'
            if (capitalizedInput.StartsWith(CommandDefaults.Place))
            {
                return ParsePlaceCommand(capitalizedInput);
            }

            // Return null if invalid
            return null;
        }

        /// <summary>
        /// Parses the <see cref="CommandDefaults.Place"/> command and its arguments
        /// </summary>
        /// <param name="capitalizedInput"></param>
        /// <returns></returns>
        private static IPlaceCommand? ParsePlaceCommand(string capitalizedInput)
        {
            var parts = capitalizedInput.Split(' ');
            // Expect the command and the argument
            // Eg: PLACE 1,2,NORTH
            if (parts.Length != 2)
            {
                return null;
            }
            var commandName = parts[0];
            var arguments = parts[1].Split(',');
            // Expect the coordinate (x,y) and the facing direction
            // Eg: 1,2,NORTH
            if (arguments.Length != 3)
            {
                return null;
            }

            // Validate data type. Expect [number number FacingDirection]
            if (!int.TryParse(arguments[0], out var inputX))
            {
                return null;
            }

            if (!int.TryParse(arguments[1], out var inputY))
            {
                return null;
            }

            if (!Enum.TryParse<DirectionType>(arguments[2], ignoreCase: true, out var direction))
            {
                return null;
            }

            return new PlaceCommand
            {
                Name = commandName,
                Position = new System.Drawing.Point(inputX, inputY),
                FacingDirection = direction,
            };
        }
    }
}
