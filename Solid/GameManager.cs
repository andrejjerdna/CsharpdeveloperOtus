using Solid.Abstractions;
using System.ComponentModel;
using System.Reflection;

namespace Solid
{
    internal class GameManager : IGameManager
    {
        private readonly IQuestionGenerator _questionGenerator;
        private readonly IAnswerChecker _answerChecker;
        private readonly IConsoleLogger _consoleLogger;
        private readonly IConsoleReader _consoleReader;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private int _number;
        private Dictionary<int, Action> _userCommands;

        private readonly List<IDigitAnswer> _incorrectAnswers;
        private readonly List<IDigitAnswer> _correctAnswers;

        public GameManager(IQuestionGenerator questionGenerator,
                           IAnswerChecker answerChecker,
                           IConsoleLogger consoleLogger,
                           IConsoleReader consoleReader)
        {
            _questionGenerator = questionGenerator;
            _answerChecker = answerChecker;
            _consoleLogger = consoleLogger;
            _consoleReader = consoleReader;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            _incorrectAnswers = new List<IDigitAnswer>();
            _correctAnswers = new List<IDigitAnswer>();

            _userCommands = GetUserCommands();
        }

        public void StartGame()
        {
            _consoleLogger.WriteMessage("Game start!");
            _consoleLogger.WriteMessage(new string('-', 80));

            _number = _consoleReader.GetDigit("Enter a number from 2 to 10");

            while (true)
            {
                if (_cancellationToken.IsCancellationRequested)
                    break;

                _consoleLogger.WriteMessage(new string('_', 80));
                StartNextSession();
                GetStatistics();
            }

            _consoleLogger.ClearConsol();
            GetStatistics();
        }

        private void GetStatistics()
        {
            if (!_incorrectAnswers.Any() && !_correctAnswers.Any())
                return;

            var message = $"Correct answers: {_correctAnswers.Count}. " +
                $"Incorrect answers: {_incorrectAnswers.Count}";

            _consoleLogger.WriteMessage(message, ConsoleColor.DarkYellow);
        }

        [Description("Restart game")]
        private void RestartGame()
        {
            _consoleLogger.ClearConsol();
            _incorrectAnswers.Clear();
            _correctAnswers.Clear();
            StartGame();
        }

        private void StartNextSession()
        {
            var question = _questionGenerator.GetQuestion(_number);
            _consoleLogger.WriteMessage(question.Title, ConsoleColor.Yellow);
            _consoleLogger.WriterQuestion(question);

            var userInput = _consoleReader.GetDigit("Please enter the answer");

            CommandCheck(userInput);

            var userAnswer = new Answer() { DigitAnswer = userInput };

            var check = _answerChecker.CheckAnswer(question.Answer, userAnswer);

            if (check)
            {
                _consoleLogger.WriteMessage("Answer is correct! Congrat!", ConsoleColor.Green);
                _correctAnswers.Add(question.Answer);
            }
            else
            {
                _consoleLogger.WriteMessage("Answer is incorrect!", ConsoleColor.Red);
                _incorrectAnswers.Add(question.Answer);
            }
        }

        private void CommandCheck(int userInput)
        {
            _userCommands.TryGetValue(userInput, out var action);
            action?.Invoke();
        }

        [Description("Stop game")]
        private void StopGame() => _cancellationTokenSource.Cancel();

        private Dictionary<int, Action> GetUserCommands()
        {
            return new Dictionary<int, Action>()
            {
                {777, () =>  RestartGame()},
                {888, () =>  StopGame()}
            };
        }
    }
}
