using SSCRobot.Common.Enums;

namespace SSCRobot.Common.Models
{
    /// <summary>
    /// Represents a robot
    /// </summary>
    public class Robot
    {
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
