using LifeGame.Cursor;
using LifeGame.Game.Objects;
using System;

namespace LifeGame.Commands
{
    internal sealed class MoveLeftCommand : MoveCommand
    {
        public MoveLeftCommand(ConsoleKey key, CursorField cursorField) : 
            base(key, cursorField)
        {
        }

        protected override Point GetPoint()
        {
            Point newPoint = _cursorField.Cursor.CursorPosition;
            if (_cursorField.Cursor.CursorPosition.X > _cursorField.Left)
            {
                --newPoint.X;
            }
            return newPoint;
        }
    }
}