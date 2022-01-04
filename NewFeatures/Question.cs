namespace NewFeatures
{
    //NEW FEATURE
    internal record Question : IQuestion
    {
        public string? Title { get; init; }
        public IAnswer? Answer { get; init; }
        public QuestionType QuestionType { get; init; }
    }
}
