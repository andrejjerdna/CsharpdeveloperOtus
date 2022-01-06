namespace Solid.Abstractions
{
    internal interface IConsoleLogger
    {
        /// <summary>
        /// Message writer
        /// </summary>
        /// <param name="message"></param>
        /// <param name="consoleColor"></param>
        void WriteMessage(string message, ConsoleColor consoleColor = ConsoleColor.White);

        /// <summary>
        /// Question writer
        /// </summary>
        /// <param name="question"></param>
        /// <param name="consoleColor"></param>
        void WriterQuestion(IQuestion question, ConsoleColor consoleColor = ConsoleColor.Magenta);

        /// <summary>
        /// Clear console
        /// </summary>
        void ClearConsol();
    }
}
