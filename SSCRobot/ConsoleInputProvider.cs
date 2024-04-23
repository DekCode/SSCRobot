namespace SSCRobot
{
    internal class ConsoleInputProvider : IInputProvider
    {
        public string? Read()
        {
            return Console.ReadLine();
        }
    }
}
