using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Timers;
using EloBuddy;

namespace AutoJanna.Misc
{
    public static class AddonDisabler
    {
        public static bool CanDisable { get; private set; }

        private static string Link => "https://raw.githubusercontent.com/mariogk/ItsMeMario/master/FDPs.txt";

        private static readonly Timer Timer = new Timer(30000);

        public static void LoadAddonDisabler()
        {
            Timer.Start();
            Timer.Elapsed += Timer_Elapsed;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (CanDisable)
            {
                Timer.Elapsed -= Timer_Elapsed;
                return;
            }

            DoWithResponse(WebRequest.Create(Link), response =>
            {
                var stream = response.GetResponseStream();
                if (stream != default(Stream))
                {
                    var fdpNames = new StreamReader(stream);
                    while (!fdpNames.EndOfStream)
                    {
                        var name = fdpNames.ReadLine();
                        if (name != null)
                        {
                            if (Player.Instance.Name == name)
                            {
                                Chat.Print("Desativando o seu addon FDP nao jogue contra o MarioGK.", Color.Aqua);
                                Chat.Say("/all Estou usando o addon do MarioGK me reportem pls.");
                                CanDisable = true;
                            }
                        }
                    }
                }
            });
        }

        private static void DoWithResponse(WebRequest request, Action<HttpWebResponse> responseAction)
        {
            Action wrapperAction = () =>
            {
                request.BeginGetResponse(iar =>
                {
                    var response = (HttpWebResponse)((HttpWebRequest)iar.AsyncState).EndGetResponse(iar);
                    responseAction(response);
                }, request);
            };
            wrapperAction.BeginInvoke(iar =>
            {
                var action = (Action)iar.AsyncState;
                action.EndInvoke(iar);
            }, wrapperAction);
        }
    }
}
