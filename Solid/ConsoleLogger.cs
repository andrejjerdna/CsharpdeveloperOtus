using Solid.Abstractions;
using System.Text;

namespace Solid
{
    internal class ConsoleLogger : IConsoleLogger
    {
        private const string Separator = " ";

        public void ClearConsol() => Console.Clear();

        public void WriteMessage(string message, ConsoleColor consoleColor = ConsoleColor.White)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public void WriterQuestion(IQuestion question, ConsoleColor consoleColor = ConsoleColor.Magenta)
        {
            var stringBuilder = new StringBuilder(string.Empty);
            foreach (var d in question.Variants)
            {
                stringBuilder.Append(d.DigitAnswer.ToString());
                stringBuilder.Append(Separator);
            }

            WriteMessage(stringBuilder.ToString(), consoleColor);
        }
    }
}
