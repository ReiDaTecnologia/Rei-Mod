using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Tiles
{

    public class TrapDoorTweak : ModPlayer // I hate how Smart Doors only works for Doors (I mean Trap Door have Door on it, right?) so i decided to make trap doors also have such feature. Press S (or whatever key you use to go down) while over the trap door for it to open and go some tiles away from it to automatically close. Press W when below it or while holding Space for it to open from below. This works regardless of the Smart Doors' setting
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            var TrapDoorPlayer = Player.GetModPlayer<ReiPlayer>();
            if (!TrapDoorPlayer.AlreadyRunning)
            {
                if (Player.controlDown && Player.releaseDown)
                {
                    TrapDoorPlayer.Y = (int)(Player.Center.Y / 16 + 2);
                    TrapDoorPlayer.X = (int)(Player.Center.X / 16 - 0.2);
                    Tile tile = Main.tile[TrapDoorPlayer.X, TrapDoorPlayer.Y];
                    if (tile.TileType == TileID.TrapdoorClosed)
                    {
                        TrapDoorPlayer.AlreadyRunning = true;
                        if (tile.TileFrameX == 0)
                        {
                            int Y2 = TrapDoorPlayer.Y + 1;
                            int X2 = TrapDoorPlayer.X + 1;
                            Tile tile2 = Main.tile[TrapDoorPlayer.X, Y2];
                            Tile tile3 = Main.tile[X2, Y2];
                            if (tile2.HasTile || tile3.HasTile)
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, false);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                            else
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, true);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                        }
                        else
                        {
                            int Y2 = TrapDoorPlayer.Y + 1;
                            int X2 = TrapDoorPlayer.X - 1;
                            Tile tile2 = Main.tile[TrapDoorPlayer.X, Y2];
                            Tile tile3 = Main.tile[X2, Y2];
                            if (tile2.HasTile || tile3.HasTile)
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, false);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                            else
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, true);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                        }
                    }
                }
                else if (Player.controlUp && Player.releaseUp || Player.controlJump)
                {
                    TrapDoorPlayer.Y = (int)(Player.Center.Y / 16 - 2);
                    TrapDoorPlayer.X = (int)(Player.Center.X / 16 - 0.2);
                    Tile tile = Main.tile[TrapDoorPlayer.X, TrapDoorPlayer.Y];
                    if (tile.TileType == TileID.TrapdoorClosed)
                    {
                        TrapDoorPlayer.AlreadyRunning = true;
                        if (tile.TileFrameX == 0)
                        {
                            int Y2 = TrapDoorPlayer.Y - 1;
                            int X2 = TrapDoorPlayer.X + 1;
                            Tile tile2 = Main.tile[TrapDoorPlayer.X, Y2];
                            Tile tile3 = Main.tile[X2, Y2];
                            if (tile2.HasTile || tile3.HasTile)
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, true);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                            else
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, false);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                        }
                        else
                        {
                            int Y2 = TrapDoorPlayer.Y + 1;
                            int X2 = TrapDoorPlayer.X - 1;
                            Tile tile2 = Main.tile[TrapDoorPlayer.X, Y2];
                            Tile tile3 = Main.tile[X2, Y2];
                            if (tile2.HasTile || tile3.HasTile)
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, false);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                            else
                            {
                                WorldGen.ShiftTrapdoor(TrapDoorPlayer.X, TrapDoorPlayer.Y, true);
                                TrapDoorPlayer.CloseTrapDoorTime = true;
                            }
                        }
                    }
                }
            }
        }
    }
}