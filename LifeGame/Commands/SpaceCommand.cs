using LifeGame.GameObjects;
using System;

namespace LifeGame.Commands
{
    internal sealed class SpaceCommand : Command
    {
        private readonly Universe _application;

        public SpaceCommand(ConsoleKey key, Universe application): 
            base(key)
        {
            _application = application;
        }

        public override void Execute()
        {
            _application.StartLife();
            _application.IsGameOver = true;
        }
    }
}