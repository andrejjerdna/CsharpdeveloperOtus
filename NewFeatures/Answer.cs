namespace NewFeatures
{
    internal class Answer : IAnswer
    {
        public Answer(string title)
        {
            Title = title;
        }

        //NEW FEATURE
        public Guid Guid { get; init; } = Guid.NewGuid();
        public string Title { get; }
    }
}
