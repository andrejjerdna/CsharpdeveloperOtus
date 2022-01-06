namespace Solid.Abstractions
{
    internal interface IAnswerChecker
    {
        /// <summary>
        /// Check user answer
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        bool CheckAnswer(IDigitAnswer answer, IDigitAnswer userAnswer);

        /// <summary>
        /// Check user answer
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        bool CheckAnswer(IStringAnswer answer, IStringAnswer userAnswer);
    }
}
