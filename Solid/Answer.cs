using Solid.Abstractions;

namespace Solid
{
    internal class Answer : IDigitAnswer, IStringAnswer
    {
        public int DigitAnswer { get; init; }
        public string StringAnswer { get; init; }
    }
}
