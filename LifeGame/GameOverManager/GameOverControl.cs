using LifeGame.Memento;
using System.Collections.Generic;

namespace LifeGame.GameOverManager
{
    internal sealed class GameOverControl
    {
        public GameOverControl()
        {
            AliveHistory = new CareTaker();
        }

        public CareTaker AliveHistory { get; private set; }

        public bool IsGameOver(IList<IGameOverStrategy> gameOverStrategies)
        {
            bool isGameOver = false;
            for (int i = 0; i < gameOverStrategies.Count; ++i)
            {
                isGameOver = gameOverStrategies[i].IsGameOver();
                if (isGameOver)
                {
                    break;
                }
            }
            return isGameOver;
        }
    }
}