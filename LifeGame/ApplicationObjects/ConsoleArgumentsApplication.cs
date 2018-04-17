using LifeGame.Exception;
using System;

namespace LifeGame.ApplicationObjects
{
    internal sealed class ConsoleArgumentsApplication : Application
    {
        private bool _isHeightSet = false;
        private bool _isWidthSet = false;

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

        public ConsoleArgumentsApplication(string[] arguments)
        {
            ReadDate(arguments);
            CheckDate();
            CreateUniverse();
        }

        private void ReadDate(string[] commandLineArguments)
        {
            foreach (var argument in commandLineArguments)
            {
                if (argument.StartsWith("h"))
                {
                    _height = Convert.ToInt32(argument.Substring(1));
                    _isHeightSet = true;
                }
                else if (argument.StartsWith("w"))
                {
                    _width = Convert.ToInt32(argument.Substring(1));
                    _isWidthSet = true;
                }
                else if(argument.StartsWith("s"))
                {
                    _delay = Convert.ToInt32(argument.Substring(1));
                }
            }
        }
    }
}