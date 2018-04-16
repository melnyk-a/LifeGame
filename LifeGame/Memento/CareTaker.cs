using System.Collections.Generic;

namespace LifeGame.Memento
{
    internal sealed class CareTaker
    {
        private readonly IList<BoardMemento> _history = new List<BoardMemento>();

        public int HistorySize { get => _history.Count; }
        public BoardMemento this[int index] { get => _history[index]; }

        public void Add(BoardMemento memento)
        {
            _history.Add(memento);
        }

        public BoardMemento GetLastMemento()
        {
            return _history[_history.Count - 1];
        }
    }
}