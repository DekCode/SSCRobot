namespace SSCRobot
{
    internal class ConsoleOutputProvider : IOutputProvider
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
