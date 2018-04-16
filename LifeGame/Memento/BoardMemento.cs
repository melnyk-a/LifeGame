using System.Collections.Generic;
using LifeGame.GameObjects;

namespace LifeGame.Memento
{
    internal sealed class BoardMemento
    {
        public BoardMemento(IList<Point> points)
        {
            AlivePoints = points;
        }

        public IList<Point> AlivePoints { get; private set; }
    }
}