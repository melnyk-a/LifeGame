using LifeGame.Exception;
using System;

namespace LifeGame.Applications
{
    internal sealed class ConsoleArgumentsApplication : Application
    {
        private const string _heightID = "h";
        private const string _speedID = "s";
        private const string _widthID = "w";
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
            int startIndexForConvert = _heightID.Length;
            foreach (var argument in commandLineArguments)
            {
                if (argument.StartsWith(_heightID))
                {
                    _isHeightSet = int.TryParse(argument.Substring(startIndexForConvert), out int height);
                    if (height != 0)
                    {
                        _height = height;
                    }
                }
                else if (argument.StartsWith(_widthID))
                {
                    _isWidthSet = int.TryParse(argument.Substring(startIndexForConvert), out int width);
                    if (width != 0)
                    {
                        _width = width;
                    }
                }
                else if (argument.StartsWith(_speedID))
                {
                    Int32.TryParse(argument.Substring(startIndexForConvert), out _delay);
                }
            }
        }
    }
}