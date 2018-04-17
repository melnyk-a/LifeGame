using LifeGame.Memento;
using System.Linq;

namespace LifeGame.GameOverManager
{
    internal sealed class NoStateChange : IGameOverStrategy
    {
        private readonly BoardMemento _currentState;
        private readonly BoardMemento _previousState;

        public NoStateChange(BoardMemento currentState, BoardMemento previousState)
        {
            _currentState = currentState;
            _previousState = previousState;
        }

        public bool IsGameOver()
        {
            return _currentState.AlivePoints.SequenceEqual(_previousState.AlivePoints);
        }
    }
}