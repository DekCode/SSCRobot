using SSCRobot.Common.Enums;

namespace SSCRobot.Common.Models
{
    public class PlaceCommand : IPlaceCommand
    {
        /// <summary>
        /// Command name
        /// </summary>
        public string Name { get; init; } = null!;

        /// <summary>
        /// Position X
        /// </summary>
        public int PositionX { get; init; }

        /// <summary>
        /// Position Y
        /// </summary>
        public int PositionY { get; init; }

        /// <summary>
        /// Facing direction
        /// </summary>
        public DirectionType FacingDirection { get; init; }
    }
}
