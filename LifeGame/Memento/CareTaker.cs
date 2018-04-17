using System.Collections.Generic;

namespace LifeGame.Memento
{
    internal sealed class CareTaker
    {
        private readonly IList<BoardMemento> _history = new List<BoardMemento>();

        public BoardMemento this[int index] { get { return _history[index]; } }

        public int HistorySize { get { return _history.Count; } }

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