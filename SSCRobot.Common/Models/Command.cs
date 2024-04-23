namespace SSCRobot.Common.Models
{
    public class Command : ICommand
    {
        /// <summary>
        /// Name of the command. Eg: PLACE, MOVE etc
        /// </summary>
        public string Name { get; init; } = null!;
    }
}
