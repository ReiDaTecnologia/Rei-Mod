using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Tiles
{
    public class CakeTweak : GlobalBuff // I found weird how Slice of Cake looks like one of the perma-buff tiles (War Table, Bewitching Table etc) yet it give a timed buff so i decided to make it permanent like the rest
    {
        public override void SetStaticDefaults()
        {
            BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = true;
            Main.buffNoTimeDisplay[BuffID.SugarRush] = true;
        }
    }
}
