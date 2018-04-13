using LifeGame.Memento;

namespace LifeGame.GameOverManager
{
    internal sealed class NoAlive : IGameOverStrategy
    {
        private readonly BoardMemento _memento;

        public NoAlive(BoardMemento memento)
        {
            _memento = memento;
        }

        public bool IsGameOver()
        {
            return _memento.AlivePoints.Count == 0;
        }
    }
}