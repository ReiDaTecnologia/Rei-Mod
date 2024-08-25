using Terraria;
using Terraria.ModLoader;

namespace ReiMod.Tiles
{
    public class AngelBlock : ModTile // Inspired from Extra Utilities' Angel Block, place the block where you click
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileBlockLight[Type] = true;
        }
    }
}
