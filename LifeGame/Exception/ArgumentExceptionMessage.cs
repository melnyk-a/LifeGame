using System;

namespace LifeGame.Exception
{
    internal static class ArgumentExceptionMessage
    {
        public static void Show(ArgumentException exception)
        {
            Console.Write("Invalid arguments: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}