using SSCRobot.Common.Enums;
using System.Drawing;

namespace SSCRobot.Common.Models
{
    /// <summary>
    /// Represents a robot
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Position
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Facing direction
        /// </summary>
        public DirectionType FacingDirection { get; set; }
    }
}
