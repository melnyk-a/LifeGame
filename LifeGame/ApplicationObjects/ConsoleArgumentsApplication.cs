using LifeGame.Exception;
using System;

namespace LifeGame.ApplicationObjects
{
    internal sealed class ConsoleArgumentsApplication : Application
    {
        private bool _isHeightSet = false;
        private bool _isWidthSet = false;

        public ConsoleArgumentsApplication(string[] arguments)
        {
            ReadDate(arguments);
            CheckDate();
            CreateUniverse();
        }

        private void ReadDate(string[] commandLineArguments)
        {
            foreach (var item in commandLineArguments)
            {
                if (item.StartsWith("h"))
                {
                    _height = Convert.ToInt32(item.Substring(1));
                    _isHeightSet = true;
                }
                if (item.StartsWith("w"))
                {
                    _width = Convert.ToInt32(item.Substring(1));
                    _isWidthSet = true;
                }
                if (item.StartsWith("s"))
                {
                    _delay = Convert.ToInt32(item.Substring(1));
                }
            }
        }

        private void CheckDate()
        {
            if (_isHeightSet && !_isWidthSet)
            {
                throw new WidthNotSpecifiedException();
            }
            else if (!_isHeightSet && _isWidthSet)
            {
                throw new HeightNotSpecifiedException();
            }
        }
    }
}