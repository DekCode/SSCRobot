using SSCRobot.Common.Enums;
using System.Drawing;

namespace SSCRobot.Common.Models
{
    /// <summary>
    /// Interface for a place command
    /// </summary>
    public interface IPlaceCommand : ICommand
    {
        /// <summary>
        /// Position
        /// </summary>
        public Point Position { get; init; }

        /// <summary>
        /// Facing direction
        /// </summary>
        public DirectionType FacingDirection { get; init; }
    }
}
