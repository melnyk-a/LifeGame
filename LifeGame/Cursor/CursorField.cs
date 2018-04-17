using LifeGame.GameObjects;

namespace LifeGame.Cursor
{
    internal sealed class CursorField
    {
        public CursorField(int left, int top, int right, int buttom, ConsoleCursor cursor)
        {
            Left = left;
            Top = top;
            Right = right;
            Buttom = buttom;
            Cursor = cursor;
            Point startPosition = new Point(Left, Top);
            Cursor.CursorPosition = startPosition;
        }

        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Buttom { get; }
        public ConsoleCursor Cursor { get; }
    }
}