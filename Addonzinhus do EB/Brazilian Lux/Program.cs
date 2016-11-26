using System.Drawing;
using BrazilianLux.Misc;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Events;

namespace BrazilianLux
{
    public class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            if (!SandboxConfig.IsBuddy)
            {
                Chat.Print("Sorry you are not buddy :(", Color.Purple);
                return;
            }

            Loading.OnLoadingComplete += delegate
            {
                VersionChecker.LoadVersionChecker();
            };
        }
    }
}
