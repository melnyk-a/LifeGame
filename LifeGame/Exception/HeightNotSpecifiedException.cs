using System;

namespace LifeGame.Exception
{
    internal sealed class HeightNotSpecifiedException : ArgumentException
    {
        public override string Message
        {
            get
            {
                return "Height of the Universe was not specified.";
            }
        }
    }
}
