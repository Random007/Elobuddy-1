using System;
using BrazilianLux.Bases;
using BrazilianLux.Misc;
using EloBuddy;

namespace BrazilianLux.Managers
{
    public static class ObjManager
    {
        public static void LoadObjManager()
        {
            GameObject.OnCreate += GameObject_OnCreate;
            GameObject.OnDelete += GameObject_OnDelete;
        }


        private static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            var particle = sender as Obj_GeneralParticleEmitter;
            if (particle != null && particle.Name.ToLower().Contains("lux_base_e_tar_aoe_green"))
            {
                Helper.EObj = particle;
            }

            var missile = sender as MissileClient;
            if(missile == null)return;

            if (missile.SpellCaster.IsMe && missile.Slot == (SpellSlot)46 || missile.Slot == (SpellSlot)49)
            {
                Helper.QObj = new QObj(missile);
            }
        }

        private static void GameObject_OnDelete(GameObject sender, EventArgs args)
        {
            var particle = sender as Obj_GeneralParticleEmitter;
            if (particle != null && particle.Name.ToLower().Contains("lux_base_e_tar_aoe_green"))
            {
                Helper.EObj = null;
            }

            var missile = sender as MissileClient;
            if (missile == null || Player.Instance.IsDead) return;

            if (missile.SpellCaster.IsMe && missile.Slot == (SpellSlot)46 || missile.Slot == (SpellSlot)49)
            {
                Helper.QObj = null;
            }
        }

    }
}
