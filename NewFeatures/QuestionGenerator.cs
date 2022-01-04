namespace NewFeatures
{
    internal class QuestionGenerator
    {
        private readonly IEnumerable<IQuestion> _questions;

        /// <summary>
        /// .ctor
        /// </summary>
        public QuestionGenerator()
        {
            _questions = GetAllQuestions();
        }

        /// <summary>
        /// Generate a new question
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public IGameItem GetNewQuestion(QuestionType questionType)
        {
            var random = new Random();

            var questionsByType = _questions.Where(q => q.QuestionType == questionType)
                                            .OrderBy(item => random.Next())
                                            .ToList();

            return new GameItem(questionsByType.First(), questionsByType.Skip(1).Take(3)
                                                                        .Select(q => q.Answer));
        }

        /// <summary>
        /// Get list of questions
        /// TODO: conect to dada base
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IQuestion> GetAllQuestions()
        {
            return new List<IQuestion>()
            {
                new Question()
                {
                    QuestionType = QuestionType.Mathematics,
                    Title = "2 + 2 = ?",
                    Answer = new Answer("4")
                },
                new Question()
                {
                    QuestionType = QuestionType.Mathematics,
                    Title = "10 + 2 = ?",
                    Answer = new Answer("12")
                },
                new Question()
                {
                    QuestionType = QuestionType.Mathematics,
                    Title = "2 + 22 = ?",
                    Answer = new Answer("24")
                },

                new Question()
                {
                    QuestionType = QuestionType.Mathematics,
                    Title = "102 + 2 = ?",
                    Answer = new Answer("104")
                },

                new Question()
                {
                    QuestionType = QuestionType.Mathematics,
                    Title = "10 / 10 = ?",
                    Answer = new Answer("1")
                },
                new Question()
                {
                    QuestionType = QuestionType.Mathematics,
                    Title = "3 * 2 = ?",
                    Answer = new Answer("5")
                },

                new Question()
                {
                    QuestionType = QuestionType.Geography,
                    Title = "How is the country the biggest?",
                    Answer = new Answer("Russia")
                },
                new Question()
                {
                    QuestionType = QuestionType.Geography,
                    Title = "What is the most populated country in the world?",
                    Answer = new Answer("China")
                },
                new Question()
                {
                    QuestionType = QuestionType.Geography,
                    Title = "Which country is the smallest?",
                    Answer = new Answer("Vatican")
                },
                new Question()
                {
                    QuestionType = QuestionType.Geography,
                    Title = "Which country is the richest in the world?",
                    Answer = new Answer("USA")
                },
            };
        }
    }
}
