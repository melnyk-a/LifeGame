using LifeGame.Cursor;
using LifeGame.GameObjects;
using System;

namespace LifeGame.Commands
{
    internal sealed class MoveUpCommand : MoveCommand
    {
        public MoveUpCommand(ConsoleKey key, CursorField field) : base(key, field)
        {

        }

        protected override Point GetPoint()
        {
            Point newPoint = _cursorField.Cursor.CursorPosition;
            if (_cursorField.Cursor.CursorPosition.Y > _cursorField.Top)
            {
                --newPoint.Y;
            }
            return newPoint;
        }
    }
}