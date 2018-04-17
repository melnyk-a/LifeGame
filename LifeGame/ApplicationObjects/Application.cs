using LifeGame.GameObjects;

namespace LifeGame.ApplicationObjects
{
    internal abstract class Application
    {
        protected int _delay = 300;
        protected int _height = 10;
        protected int _width = 40;
        private Universe _universe;

        protected void CreateUniverse()
        {
            _universe = new Universe(_width, _height, _delay);
        }

        public void Run()
        {
            _universe.Execute();
        }  
    }
}