using System.Collections.Generic;

namespace LifeGame.GameObjects
{
    internal sealed class Cell
    {
        private const char _aliveSymbol = 'O';
        private const char _deadSymbol = ' ';
        private readonly IList<Cell> _neighbors = new List<Cell>();
        private bool _isAlive;
        private char _symbol;

        public bool IsAlive
        {
            get { return _isAlive; }
            set
            {
                _isAlive = value;
                _symbol = _isAlive ? _aliveSymbol : _deadSymbol;
            }
        }

        public void AddNeighbor(Cell neighbor)
        {
            _neighbors.Add(neighbor);
        }

        public int GetAliveNeighborsCount()
        {
            int count = 0;
            for (int i = 0; i < _neighbors.Count; ++i)
            {
                if (_neighbors[i].IsAlive)
                {
                    ++count;
                }
            }
            return count;
        }

        public override string ToString()
        {
            return _symbol.ToString();
        }
    }
}