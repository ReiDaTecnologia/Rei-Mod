using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReiMod.Items
{
    public class AngelBlock : ModItem // Inspired from Extra Utilities' Angel Block, place the block where you click
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AngelBlock>());
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
            if (!tile.HasTile && !tile.HasActuator)
            {
                WorldGen.PlaceTile(point.X, point.Y, ModContent.TileType<Tiles.AngelBlock>());
                if (tile.TileType != ModContent.TileType<Tiles.AngelBlock>())
                {
                    WorldGen.PlaceTile(point.X, point.Y, ModContent.TileType<Tiles.AngelBlock>(), false, true);
                    return true;
                }
                return true;
            }
            return base.UseItem(player);
        }

        public override void HoldItem(Player player)
        {
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<AngelBlock>();
        }
    }
}
