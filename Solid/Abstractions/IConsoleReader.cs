namespace Solid.Abstractions
{
    internal interface IConsoleReader
    {
        /// <summary>
        /// Get uset input as digit
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        int GetDigit(string message);

        /// <summary>
        /// Get uset input as bool (y/n)
        /// </summary>
        /// <returns></returns>
        bool GetСonfirmation();
    }
}
