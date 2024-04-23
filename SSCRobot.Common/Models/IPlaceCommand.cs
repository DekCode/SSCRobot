using SSCRobot.Common.Enums;

namespace SSCRobot.Common.Models
{
    /// <summary>
    /// Interface for a place command
    /// </summary>
    public interface IPlaceCommand : ICommand
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
