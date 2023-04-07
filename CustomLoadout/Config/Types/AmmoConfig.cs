using System.ComponentModel;

namespace CustomLoadout.Config.Types
{
    public sealed class AmmoConfig
    {
        [Description("Should the class' amount of ammo be replaced?")]
        public bool ReplaceAmmo { get; set; }
        public ushort Ammo9 { get; set; }
        public ushort Ammo5 { get; set; }
        public ushort Ammo7 { get; set; }
        public ushort Ammo12 { get; set; }
        public ushort Ammo44 { get; set; }

        public AmmoConfig()
        {
            ReplaceAmmo = false;
            Ammo9 = 0;
            Ammo5 = 0;
            Ammo7 = 0;
            Ammo12 = 0;
            Ammo44 = 0;

        }
    }
}