using SSCRobot.Common.Enums;
using SSCRobot.Common.Models;
using System.Drawing;

namespace SSCRobot.Services
{
    /// <summary>
    /// Responsible for a <see cref="Robot"/> movement.
    /// </summary>
    public class RobotMovementService
    {
        private readonly Dictionary<DirectionType, Size> _vectors = new()
        {
            // 1 vertical unit
            {
                DirectionType.North,
                new Size(0, 1)
            },
            // -1 vertical unit
            {
                DirectionType.South,
                new Size(0, -1)
            },
            // 1 horizontal unit
            {
                DirectionType.East,
                new Size(1, 0)
            },
            // -1 horizontal unit
            {
                DirectionType.East,
                new Size(-1, 0)
            }
        };

        private readonly Dictionary<DirectionType, DirectionType> _directionClockwise = new()
        {
            { DirectionType.East, DirectionType.South  },
            { DirectionType.South, DirectionType.West  },
            { DirectionType.West, DirectionType.North  },
            { DirectionType.North, DirectionType.East  },
        };

        private readonly Dictionary<DirectionType, DirectionType> _directionCounterClockwise = new()
        {
            { DirectionType.East, DirectionType.North  },
            { DirectionType.South, DirectionType.East  },
            { DirectionType.West, DirectionType.South  },
            { DirectionType.North, DirectionType.West  },
        };

        /// <summary>
        /// Moves a <paramref name="robot"/> to the direction it's facing within a specific <paramref name="board"/> .
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="board"></param>
        public void Move(Robot robot, Board board)
        {
            // Get new position based on the direction
            var vector = _vectors[robot.FacingDirection];
            var newPosition = robot.Position + vector;

            // If the point is out of bound, ignore.
            // Notice that point is zero based index
            // Check horizontally
            if (newPosition.X < 0 || newPosition.X >= board.Width)
            {
                return;
            }
            // Check vertically
            if (newPosition.Y < 0 || newPosition.Y >= board.Height)
            {
                return;
            }

            // Assign the new position to the robot
            robot.Position = newPosition;
        }

        /// <summary>
        /// Turns left
        /// </summary>
        /// <param name="robot"></param>
        public void TurnLeft(Robot robot)
        {
            ArgumentNullException.ThrowIfNull(robot);

            var newDirection = _directionCounterClockwise[robot.FacingDirection];
            robot.FacingDirection = newDirection;
        }

        /// <summary>
        /// Turns right
        /// </summary>
        /// <param name="robot"></param>
        public void TurnRight(Robot robot)
        {
            ArgumentNullException.ThrowIfNull(robot);

            var newDirection = _directionClockwise[robot.FacingDirection];
            robot.FacingDirection = newDirection;
        }
    }
}
