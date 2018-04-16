using System.Collections.Generic;
using LifeGame.Memento;

namespace LifeGame.GameOverManager
{
    internal sealed class GameStrategyListCreator
    {
        private readonly CareTaker _history;

        public GameStrategyListCreator(CareTaker history)
        {
            _history = history;
        }

        public IList<IGameOverStrategy> Create()
        {
            IList<IGameOverStrategy> gameOverStrategies = new List<IGameOverStrategy>
            {
                CreateNoStateStategy()
            };

            if (_history.HistorySize > 1)
            {
                gameOverStrategies.Add(CreateNoStateChangeStategy());
                gameOverStrategies.Add(CreateRepeatedEarlierStrategy());
            }
            return gameOverStrategies;
        }

        private IGameOverStrategy CreateNoStateStategy()
        {
            return new NoAlive(_history.GetLastMemento());
        }

        private IGameOverStrategy CreateNoStateChangeStategy()
        {
            BoardMemento current = _history.GetLastMemento();
            BoardMemento previous = _history[_history.HistorySize - 2];
            return new NoStateChange(current,previous );
        }

        private IGameOverStrategy CreateRepeatedEarlierStrategy()
        {
            IList<BoardMemento> boardMementos = new List<BoardMemento>();
            for (int i = 0; i < _history.HistorySize; ++i)
            {
                boardMementos.Add(_history[i]);
            }
            return new RepeatedEarlier(boardMementos);
        }
    }
}