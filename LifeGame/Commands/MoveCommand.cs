using LifeGame.Cursor;
using LifeGame.GameObjects;
using System;

namespace LifeGame.Commands
{
    internal abstract class MoveCommand : Command
    {
        protected CursorField _cursorField;

        public MoveCommand(ConsoleKey key, CursorField field) : 
            base(key)
        {
            _cursorField = field;
        }

        public override void Execute()
        {
            _cursorField.Cursor.CursorPosition = GetPoint();
        }

        protected abstract Point GetPoint();
    }
}