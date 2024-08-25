using Terraria.ID;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Enums;

namespace ReiMod.Tiles
{
    public class HeightFixedStatues : ModTile // Because all statues are placeStyles of a 2x3 base statue, even if the statue is actually 2x2, it still have a hitbox of 2x3. I decided to fix that but as i couldn't fix it directly without having to touch advanced stuff like IL editing, i decided to go the method that is more of my level which is re-creating the statues with the correct height and then making a conversion recipe
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
            DustType = DustID.Silver;
            AddMapEntry(new Color(144, 148, 144), Language.GetText("MapObject.Statue"));
        }

        public override void HitWire(int i, int j)
        {
            int x = i - Main.tile[i, j].TileFrameX / 18;
            int y = j - Main.tile[i, j].TileFrameY / 18;
            const int TileWidth = 2;
            const int TileHeight = 2;
            for (int xx = x; xx < x + TileWidth; xx++)
            {
                for (int yy = y; yy < y + TileHeight; yy++)
                {
                    Wiring.SkipWire(xx, yy);
                }
            }        
            float spawnX = (x + TileWidth * 0.5f) * 16;
            float spawnY = (y + TileHeight * 0.65f) * 16;
            int spawnedNpcId = NPCID.CaveBat;
            switch(Main.tile[i, j].TileFrameY / 36)
            {
                case 0:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 6;
                    break;
                case 1:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 44;
                    spawnedNpcId = NPCID.Worm;
                    break;
                case 2:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 76;
                    spawnedNpcId = Utils.SelectRandom(Main.rand, new short[3] { NPCID.Buggy, NPCID.Sluggy, NPCID.Grubby });
                    break;
                case 3:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 109;
                    spawnedNpcId = NPCID.Mouse;
                    break;
                case 4:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 133;
                    spawnedNpcId = NPCID.Goldfish;
                    break;
                case 5:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 172;
                    spawnedNpcId = Utils.SelectRandom(Main.rand, new short[5] { NPCID.Snail, NPCID.Snail, NPCID.Snail, NPCID.Snail, NPCID.GlowingSnail });
                    break;
                case 6:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 205;
                    spawnedNpcId = NPCID.Frog;
                    break;
                case 7:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 235;
                    spawnedNpcId = Utils.SelectRandom(Main.rand, new short[2] { NPCID.Turtle, NPCID.TurtleJungle });
                    break;
                case 8:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 264;
                    spawnedNpcId = NPCID.Piranha;
                    break;
                case 9:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 294;
                    spawnedNpcId = NPCID.Shark;
                    break;
                case 11:
                    if (Main.tile[i, j].TileFrameX / 36 == 1)
                        spawnX += 32;
                    spawnY += 360;
                    spawnedNpcId = Utils.SelectRandom(Main.rand, new short[3] { NPCID.Bird, NPCID.BirdRed, NPCID.BirdBlue });
                    break;
            }
            var entitySource = new EntitySource_TileUpdate(x, y, context: "ExampleStatue");
            int npcIndex = -1;
            if (Wiring.CheckMech(x, y, 30) && NPC.MechSpawn(spawnX, spawnY, spawnedNpcId))
            {
                npcIndex = NPC.NewNPC(entitySource, (int)spawnX, (int)spawnY, spawnedNpcId);
            }
            if (npcIndex >= 0)
            {
                var npc = Main.npc[npcIndex];
                npc.value = 0f;
                npc.npcSlots = 0f;
                npc.SpawnedFromStatue = true;
            }
        }
    }
}
