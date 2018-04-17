using LifeGame.Cursor;
using LifeGame.GameObjects;
using System;

namespace LifeGame.Commands
{
    internal sealed class MoveDownCommand : MoveCommand
    {
        public MoveDownCommand(ConsoleKey key, CursorField field) : 
            base(key, field)
        {
        }

        protected override Point GetPoint()
        {
            Point newPoint = _cursorField.Cursor.CursorPosition;
            if (_cursorField.Cursor.CursorPosition.Y < _cursorField.Button)
            {
                ++newPoint.Y;
            }
            return newPoint;
        }
    }
}