namespace NewFeatures
{
    internal class GameManager
    {
        private readonly QuestionGenerator _questionGenerator;
        private readonly List<IGameItem> _incorrectAnswers;
        private readonly List<IGameItem> _correctAnswers;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="questionGenerator"></param>
        public GameManager(QuestionGenerator questionGenerator)
        {
            _questionGenerator = questionGenerator;
            _incorrectAnswers = new List<IGameItem>();
            _correctAnswers = new List<IGameItem>();
        }

        /// <summary>
        /// Star game
        /// </summary>
        public void StartGame()
        {
            WriteLine("WELCOME!", ConsoleColor.Green);
            _incorrectAnswers.Clear();
            _correctAnswers.Clear();
        }

        /// <summary>
        /// User input for continue game
        /// </summary>
        /// <returns></returns>
        public bool ContinueGame()
        {
            return UserContinueAnswer("Continue the game?");
        }

        /// <summary>
        /// Get a game statistic
        /// </summary>
        public void GetStatistic()
        {
            if(!_incorrectAnswers.Any() && !_correctAnswers.Any())
                return;

            var message = $"Correct answers: {_correctAnswers.Count}. " +
                $"Incorrect answers: {_incorrectAnswers.Count}";

            WriteLine(message, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Start a new game round
        /// </summary>
        public void StarNewGameRound()
        {
            var question = _questionGenerator.GetNewQuestion(QuestionType.Geography);

            var message = $"{question.Question.Title}: ";
            WriteLine(message, ConsoleColor.Cyan);

            var count = 1;
            foreach (var variant in question.AnswerOptions)
            {
                var variantMessage = $"{count}) {variant.Title}";
                WriteLine(variantMessage, ConsoleColor.White);
                count++;
            }

            var userInput = UserAnswer("Enter the response number:");

            if (userInput == 0)
            {
                _incorrectAnswers.Add(question);
                WriteLine("Incorrect answer!", ConsoleColor.Red);
            }

            if (question.CheckAnswer(userInput))
            {
                WriteLine("Correct answer!", ConsoleColor.Green);
                _correctAnswers.Add(question);
            }
            else
            {
                WriteLine("Incorrect answer!", ConsoleColor.Red);
                _incorrectAnswers.Add(question);
            }
        }

        /// <summary>
        /// Stop game
        /// </summary>
        public void StopGame()
        {
            WriteLine(string.Empty, ConsoleColor.DarkGray);
            WriteLine("Game is over! Your results:", ConsoleColor.Blue);
            GetStatistic();
        }

        private void WriteLine(string message, ConsoleColor consoleColor)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        private bool UserContinueAnswer(string message)
        {
            WriteLine(message + " y/n", ConsoleColor.Yellow);

            var answer = Console.ReadLine();

            if(answer == null || answer != "y")
                return false;

            return true;
        }

        private int UserAnswer(string message)
        {
            var answer = Console.ReadLine();

            if (answer == null)
                return 0;

            var result = 0;

            int.TryParse(answer, out result);

            return result;
        }
    }
}
