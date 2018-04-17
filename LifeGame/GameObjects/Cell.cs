﻿using System.Collections.Generic;

namespace LifeGame.GameObjects
{
    internal sealed class Cell
    {
        private bool _isAlive;
        private char _symbol;
        private readonly IList<Cell> _neighbors = new List<Cell>();

        public bool IsAlive
        {
            get { return _isAlive; }
            set
            {
                _isAlive = value;
                _symbol = _isAlive ? 'O' : ' ';
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