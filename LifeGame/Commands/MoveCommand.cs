using LifeGame.Cursor;
using LifeGame.Game.Objects;
using System;

namespace LifeGame.Commands
{
    internal abstract class MoveCommand : Command
    {
        protected CursorField _cursorField;

        public MoveCommand(ConsoleKey key, CursorField cursorField) : 
            base(key)
        {
            _cursorField = cursorField;
        }

        public override void Execute()
        {
            _cursorField.Cursor.CursorPosition = GetPoint();
        }

        protected abstract Point GetPoint();
    }
}