using LifeGame.Game.Objects;

namespace LifeGame.Cursor
{
    internal sealed class CursorField
    {
        public CursorField(int left, int top, int right, int bottom, ConsoleCursor cursor)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            Cursor = cursor;
            Point startPosition = new Point(Left, Top);
            Cursor.CursorPosition = startPosition;
        }

        public ConsoleCursor Cursor { get; }

        public int Bottom { get; }

        public int Left { get; }

        public int Right { get; }

        public int Top { get; }
    }
}