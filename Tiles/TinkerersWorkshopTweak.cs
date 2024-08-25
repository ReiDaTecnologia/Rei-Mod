using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Tiles
{
    public class TinkerersWorkshopTweak : GlobalTile // The Tinkerers Workshop looks like it can have stuff put above it yet you can't so i decided to allow you to put stuff above it. For some reason making Main.tileSolidTop true make the tile completely solid yet you can't put stuff above it so i had to use Main.tileSolid instead which while it don't become completely solid and you can put stuff above it, the middle shelf become solid as well and you can walk on it just like the top... It isn't a critical bug so i decided to leave it in
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[TileID.TinkerersWorkbench] = true;
            base.SetStaticDefaults();
        }
    }
}
