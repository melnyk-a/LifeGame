using LifeGame.Game.Objects;
using System.Collections.Generic;

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