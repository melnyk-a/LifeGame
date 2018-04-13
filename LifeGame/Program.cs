using LifeGame.ApplicationObjects;
using LifeGame.Exception;

namespace LifeGame
{
    internal static class Program
    {
        private static void Execute(Application application)
        {
            application.Run();
        }

        private static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                try
                {
                    Execute(new ConsoleArgumentsApplication(args));
                }
                catch (WidthNotSpecifiedException ex)
                {
                    ArgumentExceptionMessage.Show(ex);
                }
                catch (HeightNotSpecifiedException ex)
                {
                    ArgumentExceptionMessage.Show(ex);
                }
            }
            else
            {
                Execute(new DefaultApplication());
            }    
        }
    }
}