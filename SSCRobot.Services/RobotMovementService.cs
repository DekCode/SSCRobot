using SSCRobot.Common.Enums;
using SSCRobot.Common.Helpers;
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
                DirectionType.West,
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
            ArgumentNullException.ThrowIfNull(robot);
            ArgumentNullException.ThrowIfNull(board);

            // Get new position based on the direction
            var vector = _vectors[robot.FacingDirection];
            var newPosition = robot.Position + vector;

            // If the point is out of bound, ignore.
            if (!board.IsOnBoard(newPosition))
            {
                return;
            }

            // Assign the new position to the robot
            robot.Position = newPosition;
        }

        /// <summary>
        /// Turns left. The direction is relative to the robot.
        /// </summary>
        /// <param name="robot"></param>
        public void TurnLeft(Robot robot)
        {
            ArgumentNullException.ThrowIfNull(robot);

            var newDirection = _directionCounterClockwise[robot.FacingDirection];
            robot.FacingDirection = newDirection;
        }

        /// <summary>
        /// Turns right. The direction is relative to the robot.
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
