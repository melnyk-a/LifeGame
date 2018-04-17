using System;

namespace LifeGame.Commands
{
    internal abstract class Command : ICommand
    {
        private readonly ConsoleKey _key;

        public Command(ConsoleKey key)
        {
            _key = key;
        }

        public bool CanExecute(ConsoleKey key)
        {
            return _key == key;
        }

        public abstract void Execute();
    }
}