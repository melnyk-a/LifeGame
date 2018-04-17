using LifeGame.Memento;
using System.Collections.Generic;
using System.Linq;

namespace LifeGame.GameOverManager
{
    internal sealed class RepeatedEarlier : IGameOverStrategy
    {
        private readonly IList<BoardMemento> _boardMementos;

        public RepeatedEarlier(IList<BoardMemento> boardMementos)
        {
            _boardMementos = boardMementos;
        }

        public bool IsGameOver()
        {
            bool isGameOver = false;
            if (_boardMementos.Count > 1)
            {
                for (int i = 0; i < _boardMementos.Count - 1; ++i)
                {
                    for (int j = 1; j < _boardMementos.Count; ++j)
                    {
                        if (i != j)
                        {
                            isGameOver = _boardMementos[i].AlivePoints.SequenceEqual(
                            _boardMementos[j].AlivePoints);
                            if (isGameOver)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return isGameOver;
        }
    }
}