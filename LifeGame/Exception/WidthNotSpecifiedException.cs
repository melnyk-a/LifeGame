using System;

namespace LifeGame.Exception
{
    internal sealed class WidthNotSpecifiedException : ArgumentException
    {
        public override string Message
        {
            get { return "Width of the Universe was not specified."; }
        }
    }
}