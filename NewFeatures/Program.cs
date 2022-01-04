//NEW FEATURE
using NewFeatures;

//NEW FEATURE
QuestionGenerator questionGenerator = new();
GameManager gameManager = new(questionGenerator);

gameManager.StartGame();

while (true)
{
    gameManager.GetStatistic();

    gameManager.StarNewGameRound();

    var userInput = gameManager.ContinueGame();

    if (userInput == false)
    {
        gameManager.StopGame();
        break;
    }
}
