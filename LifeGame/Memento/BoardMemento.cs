using System.Collections.Generic;
using LifeGame.GameObjects;

namespace LifeGame.Memento
{
    internal sealed class BoardMemento
    {
        public BoardMemento(List<Point> points)
        {
            AlivePoints = points;
        }

        public List<Point> AlivePoints { get; private set; }
    }
}