using LifeGame.Cursor;
using LifeGame.Game.Objects;
using System;

namespace LifeGame.Commands
{
    internal sealed class MoveUpCommand : MoveCommand
    {
        public MoveUpCommand(ConsoleKey key, CursorField cursorField) : 
            base(key, cursorField)
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