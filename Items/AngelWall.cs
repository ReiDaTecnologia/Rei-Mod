using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class AngelWall : ModItem // Similar to Angel Block but wall version, it also force-replace walls so it can be also used to easily replace underground walls (as hammers don't break em for some reason)
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Walls.AngelWall>());
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 15000;
            Item.useAnimation = 15;
            Item.useTime = 15;
            ItemID.Sets.SortingPriorityMaterials[Type] = 69;
        }

        public override bool? UseItem(Player player)
        {
            Point point = Main.MouseWorld.ToTileCoordinates();
            Tile tile = Main.tile[point.X, point.Y];
            if (tile.WallType != ModContent.WallType<Walls.AngelWall>())
            {
                WorldGen.PlaceWall(point.X, point.Y, ModContent.WallType<Walls.AngelWall>());
                if (tile.WallType != ModContent.WallType<Walls.AngelWall>())
                {
                    WorldGen.ReplaceWall(point.X, point.Y, (ushort)ModContent.WallType<Walls.AngelWall>());
                    return true;
                }
                return true;
            }
            return base.UseItem(player);
        }

        public override void HoldItem(Player player)
        {
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<AngelWall>();
        }
    }
}
