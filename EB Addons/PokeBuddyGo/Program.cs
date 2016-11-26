using EloBuddy.SDK.Events;

namespace PokeBuddyGo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(System.EventArgs args)
        {
            Loader.Load();
        }
    }
}
