using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Newtonsoft.Json;

namespace BrazilianLux.Bases
{
    public enum ModesEnum
    {
        Combo = 0,
        Harass = 1,
        Laneclear = 2,
        Lasthit = 3,
        Killsteal = 4,
        Gapcloser = 5,
        Interrupter = 6
    }

    public class PredictionSlider
    {
        public List<ModesEnum> Modes;

        public ComboBox Combobox;
        public Slider Slider;

        private ModesEnum CurrentMode;

        private Dictionary<ModesEnum, int> PredictionRates = new Dictionary<ModesEnum, int>();

        private SpellSlot slot;
        private Timer Timer;

        public PredictionSlider(Menu menu, string id, Spell.SpellBase spell, bool haveGapcloser = false, bool haveInterrupter = false)
        {
            slot = spell.Slot;
            Timer = new Timer(100000);
            Timer.Start();
            Timer.Elapsed += Timer_Elapsed;

            menu.AddGroupLabel("Choose the prediction rate for the spell "+ spell.Slot);
            
            var modeList = new List<ModesEnum> {ModesEnum.Combo,ModesEnum.Harass,ModesEnum.Laneclear,ModesEnum.Lasthit, ModesEnum.Killsteal};
            if (haveGapcloser)
            {
                modeList.Add(ModesEnum.Gapcloser);
            }
            if (haveInterrupter)
            {
                modeList.Add(ModesEnum.Interrupter);
            }

            Combobox = new ComboBox("Select the mode to change the prediction rate", modeList.Select(m => m.ToString()));
            CurrentMode = (ModesEnum)Combobox.CurrentValue;
            Slider = new Slider("Will cast the spell if the hichance percent is higher than [{0}] for the "+ CurrentMode + " mode", 60);

            menu.Add(id + "combobox", Combobox);
            menu.Add(id + "slider", Slider);

            PredictionRates.Add(ModesEnum.Combo, Slider.CurrentValue);
            PredictionRates.Add(ModesEnum.Harass, Slider.CurrentValue);
            PredictionRates.Add(ModesEnum.Laneclear, Slider.CurrentValue);
            PredictionRates.Add(ModesEnum.Lasthit, Slider.CurrentValue);
            PredictionRates.Add(ModesEnum.Killsteal, Slider.CurrentValue);
            if (haveInterrupter)
            {
                PredictionRates.Add(ModesEnum.Interrupter, Slider.CurrentValue);
            }
            if (haveGapcloser)
            {
                PredictionRates.Add(ModesEnum.Gapcloser, Slider.CurrentValue);
            }

            Combobox.OnValueChange += Combobox_OnValueChange;
            Slider.OnValueChange += Slider_OnValueChange;

            LoadFromFile();
            UpdateTexts();
        }

        public int GetPredictionValue(ModesEnum mode)
        {
            return PredictionRates[mode];
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SaveChanges();
        }

        private void Slider_OnValueChange(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
        {
            PredictionRates[CurrentMode] = Slider.CurrentValue;
        }

        private void Combobox_OnValueChange(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
        {
            CurrentMode = (ModesEnum) Combobox.CurrentValue;
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            Slider.DisplayName = "Will cast the spell if the hichance percent is higher than [{0}] for the " + CurrentMode+" mode";
            Slider.CurrentValue = PredictionRates[CurrentMode];
        }

        private void LoadFromFile()
        {
            var mainDirectory = Path.Combine(SandboxConfig.DataDirectory, "Apollyon");

            if (!Directory.Exists(mainDirectory))
            {
                return;
            }

            var savePath = Path.Combine(mainDirectory, Loader.Name + "menudata" + slot + ".json");
            if (!File.Exists(savePath))
            {
                return;
            }

            var reader = new StreamReader(savePath);
            var jsonString = reader.ReadToEnd();
            reader.Close();
            var deserialized = JsonConvert.DeserializeObject<Dictionary<ModesEnum, int>>(jsonString);
            if (deserialized == null)
            {
                Chat.Print("Save Data Null Contact Apollyon plz");
            }

            PredictionRates = deserialized;

        }

        private void SaveChanges()
        {
            var serialized = JsonConvert.SerializeObject(PredictionRates);

            var mainDirectory = Path.Combine(SandboxConfig.DataDirectory, "Apollyon");

            if (!Directory.Exists(mainDirectory))
            {
                Directory.CreateDirectory(mainDirectory);
            }

            var savePath= Path.Combine(mainDirectory, Loader.Name + "menudata"+slot+".json");
            if (!File.Exists(savePath))
            {
                File.Create(savePath).Close();
            }

            File.WriteAllText(savePath, serialized);
        }
    }
}
