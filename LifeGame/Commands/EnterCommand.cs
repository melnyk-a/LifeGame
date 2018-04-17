using LifeGame.Cursor;
using LifeGame.GameObjects;
using System;

namespace LifeGame.Commands
{
    internal sealed class EnterCommand : Command
    {
        private readonly GameBoard _board;
        private readonly CursorField _field;

        public EnterCommand(ConsoleKey key, CursorField field, GameBoard gameBoard) : 
            base(key)
        {
            _board = gameBoard;
            _field = field;
        }

        public override void Execute()
        {
            int rowIndex = _field.Cursor.CursorPosition.Y - _field.Top;
            int collumIndex = _field.Cursor.CursorPosition.X - _field.Left;
            Cell cell = _board[rowIndex, collumIndex];
            cell.IsAlive = !cell.IsAlive;
        }
    }
}