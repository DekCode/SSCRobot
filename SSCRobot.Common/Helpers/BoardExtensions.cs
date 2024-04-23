using SSCRobot.Common.Models;
using System.Drawing;

namespace SSCRobot.Common.Helpers
{
    public static class BoardExtensions
    {
        /// <summary>
        /// Checks if the point is on the <paramref name="board"/> .
        /// </summary>
        /// <param name="board"></param>
        /// <param name="robot"></param>
        public static bool IsOnBoard(this Board board, Point point)
        {
            // Check horizontally
            if (point.X < 0 || point.X >= board.Width)
            {
                return false;
            }
            // Check vertically
            if (point.Y < 0 || point.Y >= board.Height)
            {
                return false;
            }

            return true;
        }
    }
}
