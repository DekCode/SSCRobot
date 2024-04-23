using SSCRobot.Common.Enums;
using System.Drawing;

namespace SSCRobot.Common.Models
{
    public class PlaceCommand : IPlaceCommand
    {
        /// <summary>
        /// Command name
        /// </summary>
        public string Name { get; init; } = null!;

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
