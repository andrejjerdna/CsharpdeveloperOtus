using Solid.Abstractions;

namespace Solid
{
    internal class ConsoleReader : IConsoleReader
    {
        private readonly IConsoleLogger _consoleLogger;

        public ConsoleReader(IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
        }
        public int GetDigit(string message)
        {
            _consoleLogger.WriteMessage(message, ConsoleColor.Blue);

            var answer = Console.ReadLine();

            if (answer == null)
                return 0;

            var result = 0;

            int.TryParse(answer, out result);

            return result;
        }

        public bool GetСonfirmation()
        {
            var answer = Console.ReadLine();

            if (answer == null || answer != "y")
                return false;

            return true;
        }
    }
}
