using Solid;
using Solid.Abstractions;

var container = ContainerConfigure.GetContainer();

var gameManager = container.GetRequiredService<IGameManager>();
gameManager.StartGame();
