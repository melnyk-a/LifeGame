using LifeGame.Exception;
using System;

namespace LifeGame.ApplicationObjects
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
                    _height = Convert.ToInt32(argument.Substring(startIndexForConvert));
                    _isHeightSet = true;
                }
                else if (argument.StartsWith(_widthID))
                {
                    _width = Convert.ToInt32(argument.Substring(startIndexForConvert));
                    _isWidthSet = true;
                }
                else if(argument.StartsWith(_speedID))
                {
                    _delay = Convert.ToInt32(argument.Substring(startIndexForConvert));
                }
            }
        }
    }
}