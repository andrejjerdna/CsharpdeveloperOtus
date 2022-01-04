namespace NewFeatures
{
    internal interface IQuestion
    {
        //NEW FEATURE
        /// <summary>
        /// Title
        /// </summary>
        string Title { get; init; }

        /// <summary>
        /// Answer
        /// </summary>
        IAnswer Answer { get; init; }

        /// <summary>
        /// Question type
        /// </summary>
        QuestionType QuestionType { get; init; }
    }
}
