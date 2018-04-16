using LifeGame.Cursor;
using LifeGame.GameObjects;
using System;

namespace LifeGame.Commands
{
    internal sealed class MoveRightCommand : MoveCommand
    {
        public MoveRightCommand(ConsoleKey key, CursorField field) : base(key, field)
        {
        }

        protected override Point GetPoint()
        {
            Point newPoint = _cursorField.Cursor.CursorPosition;
            if (_cursorField.Cursor.CursorPosition.X < _cursorField.Right)
            {
                ++newPoint.X;
            }
            return newPoint;
        }
    }
}