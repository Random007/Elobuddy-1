using EloBuddy;
using EloBuddy.SDK.Events;

namespace Nautilus
{
    public class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += delegate
            {
                VersionChecker.LoadVersionChecker();
                /*Chat.Say("/Load");*/
            };
        }
    }
}
