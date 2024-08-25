using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ReiMod.Tiles
{
    public class MossTweak : GlobalTile // Because i wanted to decorate my base with Lava Moss and for some reason the lava moss drop only 11.11% of the time while using the Paint Scraper, i decided to make the Lava Moss drop 100% of the time with any tool but as i couldn't find a way to make Lava Moss stop dropping the Lava Moss when using Paint Scraper, you can get 2 Lava Moss with 11.11% chance while using the Paint Scraper... Bug or feature?
    {
        public override void Drop(int i, int j, int type)
        {
            if (type == TileID.LongMoss)
            {
                Vector2 pos = new Vector2(i, j) * 16;
                Tile tile = Main.tile[i, j];
                if (tile.TileFrameX == 110)
                    Item.NewItem(new EntitySource_TileBreak(i, j), pos, ItemID.LavaMoss);
                else if (tile.TileFrameX == 154)
                    Item.NewItem(new EntitySource_TileBreak(i, j), pos, ItemID.XenonMoss);
            }
        }
    }
}