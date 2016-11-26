using AutoJanna.Misc;
using EloBuddy.SDK.Events;

namespace AutoJanna
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
