using SSCRobot.Common.Helpers;
using SSCRobot.Common.Models;

namespace SSCRobot.Services
{
    /// <summary>
    /// Reponsible for a robot placement
    /// </summary>
    public class RobotPlacementService
    {
        /// <summary>
        /// Tries place a robot on the <paramref name="board"/> from the place command.
        /// </summary>
        /// <param name="placeCommand"></param>
        /// <param name="board"></param>
        /// <returns>A successfully placed <see cref="Robot"/> or <see langword="null"/> if the place command is invalid</returns>
        public Robot? PlaceRobot(IPlaceCommand placeCommand, Board board)
        {
            ArgumentNullException.ThrowIfNull(placeCommand, nameof(placeCommand));
            ArgumentNullException.ThrowIfNull(board, nameof(board));

            // Validate position
            if (!board.IsOnBoard(placeCommand.Position))
            {
                return null;
            }

            return new Robot
            {
                Position = placeCommand.Position,
                FacingDirection = placeCommand.FacingDirection,
            };
        }
    }
}
