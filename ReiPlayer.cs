using Microsoft.Xna.Framework;
using Terraria.GameInput;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using Terraria.ID;

namespace ReiMod
{
    public class ReiPlayer : ModPlayer // Main ModPlayer file
    {
        public bool CloseTrapDoorTime;
        public bool AlreadyRunning;
        public bool UsedManaJuice;
        public bool UsedLifeJuice;
        public bool AllowAnimationTime;
        public int ManaJuiceCooldown;
        public int LifeJuiceCooldown;
        public int AnimationTime;
        public int X;
        public int Y;

        public override void SaveData(TagCompound tag) // Save & Load, the Mana and Life Juice data
        {
            tag["UsedManaJuice"] = UsedManaJuice;
            tag["UsedLifeJuice"] = UsedLifeJuice;
        }

        public override void LoadData(TagCompound tag)
        {
            UsedManaJuice = tag.GetBool("UsedManaJuice");
            UsedLifeJuice = tag.GetBool("UsedLifeJuice");
        }

        public override void PreUpdate() // Used for timers and cooldown as tML suggest it for
        {
            if (ManaJuiceCooldown > 0)
                ManaJuiceCooldown--;
            if (LifeJuiceCooldown > 0)
                LifeJuiceCooldown--;
            if (AllowAnimationTime)
            {
                AnimationTime--;
                if (AnimationTime == 0)
                {
                    Player.PotionOfReturnHomePosition = Player.Bottom;
                    AllowAnimationTime = false;
                }
            }
            base.PreUpdate();
        }

        public override void PostUpdate() // Used for the Trap Door tweak and Life Juice's passive ability (cooldown included)
        {
            if (CloseTrapDoorTime)
            {
                int Y2 = (int)(Player.Center.Y / 16 + 2);
                int X2 = (int)(Player.Center.X / 16);
                if (Math.Abs(Y - Y2) >= 2 || Math.Abs(X - X2) >= 2.5)
                {
                    WorldGen.ShiftTrapdoor(X, Y, false);
                    Tile tile = Main.tile[X, Y];
                    if (tile.TileType == TileID.TrapdoorClosed)
                    {
                        CloseTrapDoorTime = false;
                        AlreadyRunning = false;
                    }
                }
            }
            if (Player.statLife <= 100 && UsedLifeJuice && LifeJuiceCooldown == 0)
            {
                int HealAmount = Math.Abs(Player.statLife - Player.statLifeMax2);
                Player.Heal(HealAmount);
                LifeJuiceCooldown = 3600;
            }
        }

        public override void OnMissingMana(Item item, int neededMana) // Used for Mana Juice's passive ability (cooldown included)
        {
            if (UsedManaJuice && ManaJuiceCooldown == 0)
            {
                Player.statMana += neededMana;
                ManaJuiceCooldown = 600;
            }
            base.OnMissingMana(item, neededMana);
        }

        /*public override void ProcessTriggers(TriggersSet triggersSet) // For testing purposes only. Say in the chat the tile's placeStyle, Alternate, general tile info and the tile location that you clicked
        {
            if (Main.mouseRight && Main.mouseRightRelease)
            {
                Point point = Main.MouseWorld.ToTileCoordinates();
                Tile tile = Main.tile[point.X, point.Y];
                const int TileHeight = 36; // Change this to the amount of vertical pixels the tile has (if the texture has multiple styles pilled vertically or horizontally, use the amount of pixels of the desired style) to know the placeStyle of it
                const int TileWidth = 36; // Change this to the amount of horizontal pixels the tile has (if the texture has multiple styles pilled vertically or horizontally, use the amount of pixels of the desired style) to know the alternate of it
                Main.NewText($"Style:{tile.TileFrameY / TileHeight} Alternate:{tile.TileFrameX / TileWidth}");
                Main.NewText($"{tile} Tile X:{point.X} Tile Y:{point.Y}");
            }
            base.ProcessTriggers(triggersSet);
        }*/
    }
}
