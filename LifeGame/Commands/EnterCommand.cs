﻿using LifeGame.Cursor;
using LifeGame.Game.Objects;
using System;

namespace LifeGame.Commands
{
    internal sealed class EnterCommand : Command
    {
        private readonly GameBoard _board;
        private readonly CursorField _field;

        public EnterCommand(ConsoleKey key, CursorField field, GameBoard board) : 
            base(key)
        {
            _board = board;
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