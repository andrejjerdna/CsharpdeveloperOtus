using Solid.Abstractions;

namespace Solid
{
    internal class QuestionGenerator : IQuestionGenerator
    {
        private readonly Random _random = new Random();
        public IQuestion GetQuestion(int number)
        {
            var maxDigit = 100;

            if (number > maxDigit)
                throw new Exception("A digit greater than 100!");

            if (number <= 0)
                throw new Exception("A digit is less than or equal to 0!");

            var rightAnswer = _random.Next(0, maxDigit);

            var variants = Enumerable.Range(0, maxDigit)
                                       .Where(digit => digit != rightAnswer)
                                       .OrderBy(item => _random.Next())
                                       .Take(number - 1)
                                       .Select(digit => new Answer() { DigitAnswer = digit });

            var answer = new Answer
            {
                DigitAnswer = rightAnswer,
            };

            var variantsResult = new List<IDigitAnswer> { answer };
            variantsResult.AddRange(variants);

            var title = $"Choose one number out of {number}";

            return new Question()
            { 
                Answer = answer,
                Title = title,
                Variants = variantsResult.OrderBy(item => _random.Next())
            };
        }
    }
}
