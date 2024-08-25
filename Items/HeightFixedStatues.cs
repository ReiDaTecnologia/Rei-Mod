using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class HeightFixedStatues_Bat : ModItem // Because all statues are placeStyles of a 2x3 base statue, even if the statue is actually 2x2, it still have a hitbox of 2x3. I decided to fix that but as i couldn't fix it directly without having to touch advanced stuff like IL editing, i decided to go the method that is more of my level which is re-creating the statues with the correct height and then making a conversion recipe
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BatStatue);
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 0;
        }
    }

    public class HeightFixedStatues_Worm : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WormStatue);
            Item.width = 28;
            Item.height = 24;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 1;
        }
    }

    public class HeightFixedStatues_Buggy : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BuggyStatue);
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 2;
        }
    }

    public class HeightFixedStatues_Mouse : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MouseStatue);
            Item.width = 28;
            Item.height = 32;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 3;
        }
    }

    public class HeightFixedStatues_Fish : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishStatue);
            Item.width = 28;
            Item.height = 24;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 4;
        }
    }

    public class HeightFixedStatues_Snail : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SnailStatue);
            Item.width = 28;
            Item.height = 26;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 5;
        }
    }

    public class HeightFixedStatues_Frog : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FrogStatue);
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 6;
        }
    }

    public class HeightFixedStatues_Turtle : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TurtleStatue);
            Item.width = 36;
            Item.height = 36;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 7;
        }
    }

    public class HeightFixedStatues_Piranha : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PiranhaStatue);
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 8;
        }
    }

    public class HeightFixedStatues_Shark : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SharkStatue);
            Item.width = 28;
            Item.height = 26;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 9;
        }
    }

    public class HeightFixedStatues_Anvil : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AnvilStatue);
            Item.width = 28;
            Item.height = 26;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 10;
        }
    }

    public class HeightFixedStatues_Bird : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BirdStatue);
            Item.width = 28;
            Item.height = 30;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<Tiles.HeightFixedStatues>();
            Item.placeStyle = 11;
        }
    }
}
