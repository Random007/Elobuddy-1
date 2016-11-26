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
                VersionChecker.LoadVersionChecker();
            };
        }
    }
}
