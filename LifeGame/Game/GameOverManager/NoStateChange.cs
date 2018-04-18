using LifeGame.Memento;
using System.Linq;

namespace LifeGame.Game.GameOverManager
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

        public bool IsGameOver
        {
            get { return _currentState.AlivePoints.SequenceEqual(_previousState.AlivePoints); }
        }
    }
}