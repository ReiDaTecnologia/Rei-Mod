using Terraria;
using Terraria.ModLoader;

namespace ReiMod.Walls
{
    public class AngelWall : ModWall // Similar to Angel Block but wall version, it also force-replace walls so it can be also used to easily replace underground walls (as hammers don't break em for some reason)
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
        }
    }
}
