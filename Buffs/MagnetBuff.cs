using Terraria;
using Terraria.ModLoader;

namespace ReiMod.Buffs
{
    public class MagnetBuff : ModBuff // The buff that you get from the Magnet Potion
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.treasureMagnet = true;
            base.Update(player, ref buffIndex);
        }
    }
}
