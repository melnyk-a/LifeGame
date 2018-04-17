using LifeGame.GameObjects;

namespace LifeGame.Cursor
{
    internal sealed class CursorField
    {
        public CursorField(int left, int top, int right, int button, ConsoleCursor cursor)
        {
            Left = left;
            Top = top;
            Right = right;
            Button = button;
            Cursor = cursor;
            Point startPosition = new Point(Left, Top);
            Cursor.CursorPosition = startPosition;
        }

        public ConsoleCursor Cursor { get; }
        public int Button { get; }
        public int Left { get; }
        public int Right { get; }
        public int Top { get; }
    }
}