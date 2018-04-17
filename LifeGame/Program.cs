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

        private static void Main(string[] commandLineArguments)
        {
            if (commandLineArguments.Length != 0)
            {
                try
                {
                    Execute(new ConsoleArgumentsApplication(commandLineArguments));
                }
                catch (WidthNotSpecifiedException exception)
                {
                    ArgumentExceptionMessage.Show(exception);
                }
                catch (HeightNotSpecifiedException exception)
                {
                    ArgumentExceptionMessage.Show(exception);
                }
            }
            else
            {
                Execute(new DefaultApplication());
            }    
        }
    }
}