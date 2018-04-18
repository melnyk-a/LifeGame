using System;

namespace LifeGame.Game.Objects
{
    internal sealed class Generation
    {
        private int _count;

        public void Show()
        {
            Console.Write("Generation: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(_count);
            Console.ResetColor();
        }

        public static Generation operator ++(Generation generation)
        {
            ++generation._count;
            return generation;
        }
    }
}