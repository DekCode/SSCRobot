namespace SSCRobot.Common.Models
{
    /// <summary>
    /// Represents a board with the bottom-left cornner is (0,0) for the x and y position.
    /// </summary>
    public class Board
    {
        public int[,] Grid { get; set; }

        /// <summary>
        /// Initilizes a new board with the specified dimension.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Board(int width, int height)
        {
            Grid = new int[width, height];
        }
    }
}
