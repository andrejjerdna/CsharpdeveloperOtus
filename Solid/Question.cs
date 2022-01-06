using Solid.Abstractions;

namespace Solid
{
    internal class Question : IQuestion
    {
        public string Title { get; init; }
        public IDigitAnswer Answer { get; init; }
        public IEnumerable<IDigitAnswer> Variants { get; init; }
    }
}
