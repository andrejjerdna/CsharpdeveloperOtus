namespace NewFeatures
{
    internal class GameItem : IGameItem
    {
        private readonly IQuestion _question;
        private readonly Random _random;
        private List<IAnswer> _answerOptions;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="question"></param>
        /// <param name="fakeAnswers"></param>
        public GameItem(IQuestion question, IEnumerable<IAnswer> fakeAnswers)
        {
            _question = question;
            _random = new Random();
            _answerOptions = new List<IAnswer>
            {
                _question.Answer
            };

            _answerOptions.AddRange(fakeAnswers);
            _answerOptions = _answerOptions.OrderBy(item => _random.Next()).ToList();
        }
        public IQuestion Question => _question;
        public IEnumerable<IAnswer> AnswerOptions => _answerOptions;
        public bool CheckAnswer(int userAnswer)
        {
            try
            {
                return _answerOptions.ElementAt(userAnswer - 1).Guid == _question.Answer.Guid;
            }
            catch
            {
                return false;
            }
        }
    }
}
