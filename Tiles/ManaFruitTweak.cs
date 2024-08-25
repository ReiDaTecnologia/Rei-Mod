using Terraria;
using Terraria.ModLoader;

namespace ReiMod.Tiles
{
    public class ManaFruitTweak : GlobalTile // Make the Mana Fruit Mod's mana fruit emit a blue light so you can easily find it just like the mod Heart Crystal & Life Fruit Glow do with Heart Crystals and Life Fruits. Don't take effect if Mana Fruit Mod isn't installed
    {
        public override void SetStaticDefaults()
        {
            if (ModContent.TryFind("ManaFruit", "ManaFruitTile", out ModTile ManaFruitTile))
            {
                Main.tileLighted[ManaFruitTile.Type] = true;
                Main.tileOreFinderPriority[ManaFruitTile.Type] = 809;
            }
        }
        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            if (ModContent.TryFind("ManaFruit", "ManaFruitTile", out ModTile ManaFruitTile))
            {
                if (type == ManaFruitTile.Type)
                {
                    r = 0f;
                    g = 0f;
                    b = 1f;
                }
            }
        }
    }
}
