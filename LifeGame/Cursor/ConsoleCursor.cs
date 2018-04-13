using LifeGame.GameObjects;
using System;

namespace LifeGame.Cursor
{
    internal sealed class ConsoleCursor
    {
        public Point CursorPosition { get; set; }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
            Console.Write('X');
            Console.ResetColor();
            Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
        }
    }
}