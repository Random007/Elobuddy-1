using System.Drawing;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK.Events;
using Template.Misc;

namespace Template
{
    public class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += delegate
            {
                //TODO
                //if (Champ != Player.Instance.Hero) return;

                if (!SandboxConfig.IsBuddy)
                {
                    Chat.Print("Sorry you are not buddy :(", Color.Purple);
                    return;
                }
                VersionChecker.LoadVersionChecker();
            };
        }
    }
}
