namespace Solid.Abstractions
{
    internal interface IQuestionGenerator
    {
        /// <summary>
        /// Get question by number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        IQuestion GetQuestion(int number);
    }
}
