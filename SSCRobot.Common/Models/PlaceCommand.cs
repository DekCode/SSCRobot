using SSCRobot.Common.Enums;

namespace SSCRobot.Common.Models
{
    public class PlaceCommand : IPlaceCommand
    {
        /// <summary>
        /// Command name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Position X
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Position Y
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Facing direction
        /// </summary>
        public DirectionType FacingDirection { get; set; }
    }
}
