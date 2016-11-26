using EloBuddy.SDK.Events;

namespace BlackYasuo
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += delegate
            {
                Loader.Load();
            };
        }
    }
}
