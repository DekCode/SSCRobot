namespace SSCRobot.Common.Models
{
    public interface ICommand
    {
        /// <summary>
        /// Name of the command. Eg: PLACE, MOVE etc
        /// </summary>
        public string Name { get; init; }
    }
}
