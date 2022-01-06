namespace Solid.Abstractions
{
    internal interface IQuestion
    {
        /// <summary>
        /// Question title
        /// </summary>
        string Title { get; init; }

        /// <summary>
        /// A right answer
        /// </summary>
        IDigitAnswer Answer { get; init; }

        /// <summary>
        /// Answers with a right answer
        /// </summary>
        IEnumerable<IDigitAnswer> Variants { get; init; }
    }
}
