using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

using Version = System.Version;

namespace BlackYasuo
{
    public static class Loader
    {
        private static Champion Champ => Champion.Yasuo;
        public static string Name => "BlackYasuo";

        private static string VersionUrl
            => "https://raw.githubusercontent.com/mariogk/BuddyOnly/master/" + Name + "/" + Name + ".version";

        internal static bool VersionChecked;
        internal static bool Loaded;

        private static Version LocalVersion => Assembly.GetExecutingAssembly().GetName().Version;

        public static void Load()
        {
            if (Champ != Player.Instance.Hero) return;

            VersionChecked = false;
            Loaded = false;

            CheckVersion();

            Game.OnTick += Game_OnTick;
            Chat.OnInput += Chat_OnInput;
        }


        private static void LoadFeatures()
        {
            Helper.Load();
            SpellManager.Load();

            MyMenu.Load();
            ModeManager.Load();
            DrawingManager.Load();

            DashManager.Load();
        }


        private static void Game_OnTick(EventArgs args)
        {
            if (!VersionChecked) return;

            if (Loaded)
            {
                Chat.OnInput -= Chat_OnInput;
                Game.OnTick -= Game_OnTick;
            }
            else
            {
                Loaded = true;
                LoadFeatures();
            }
        }

        private static void Chat_OnInput(ChatInputEventArgs args)
        {
            if (!args.Input.Contains("/load")) return;

            args.Process = false;
            Core.DelayAction(() => Chat.Print("Loading " + Name + " now!", Color.GreenYellow), 200);
            Core.DelayAction(() => VersionChecked = true, 400);
        }

        private static void DoWithResponse(WebRequest request, Action<HttpWebResponse> responseAction)
        {
            Action wrapperAction = () =>
            {
                request.BeginGetResponse(iar =>
                {
                    var response = (HttpWebResponse) ((HttpWebRequest) iar.AsyncState).EndGetResponse(iar);
                    responseAction(response);
                }, request);
            };
            wrapperAction.BeginInvoke(iar =>
            {
                var action = (Action) iar.AsyncState;
                action.EndInvoke(iar);
            }, wrapperAction);
        }

        private static void CheckVersion()
        {
            DoWithResponse(WebRequest.Create(VersionUrl), response =>
            {
                var stream = response.GetResponseStream();
                if (stream != default(Stream))
                {
                    var internetVersion = new Version(new StreamReader(stream).ReadToEnd());
                    if (!internetVersion.Equals(LocalVersion))
                    {
                        Chat.Print(
                            "New version found(" + internetVersion +
                            ") of " + Name + " please update it.(To load it anyway type /load)", Color.Red);
                    }
                    else
                    {
                        VersionChecked = true;
                    }
                }
                else
                {
                    Chat.Print("An error happened while trying to check your version, try again.");
                }
            });
        }
    }
}
