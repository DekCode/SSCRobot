using SSCRobot.Common.Constants;
using SSCRobot.Common.Enums;
using SSCRobot.Common.Models;
using System.Windows.Input;

namespace SSCRobot.Services
{
    /// <summary>
    /// A command parser
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
        /// <returns>An implementation of <see cref="ICommand"/></returns>
        public static ICommand? Parse(string commandString)
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

            // Parse a place command
            if (capitalizedInput.StartsWith(CommandDefaults.Place))
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
                    PositionX = inputX,
                    PositionY = inputY,
                    FacingDirection = direction,
                };
            }

            // Return null if invalid
            return null;
        }
    }
}
