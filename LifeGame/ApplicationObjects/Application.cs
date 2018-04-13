using LifeGame.GameObjects;

namespace LifeGame.ApplicationObjects
{
    internal abstract class Application
    {
        protected int _width = 40;
        protected int _height = 10;
        protected int _delay = 300;
        private Universe _universe;

        public void Run()
        {
            _universe.Execute();
        }

        protected void CreateUniverse()
        {
            _universe = new Universe(_width, _height, _delay);
        }
    }
}