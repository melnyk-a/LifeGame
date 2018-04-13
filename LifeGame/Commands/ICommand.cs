using System;

namespace LifeGame.Commands
{
    internal interface ICommand
    {
        bool CanExecute(ConsoleKey key);

        void Execute();
    }
}