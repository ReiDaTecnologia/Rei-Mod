using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class GuideVoodooDollTweak : ModSystem // I don't like how you can summon the Wall of Flesh by accident so this tweak make the WOF only spawn if the Guide Voodoo Doll is directly dropped by the player
    {
        public static bool CanSpawnWoF = false;
        public override void Load()
        {
            On_Item.CheckLavaDeath += CheckLavaDeathTweak;
        }
        private static void CheckLavaDeathTweak(On_Item.orig_CheckLavaDeath orig, Item self, int i)
        {
            if (self.type == ItemID.GuideVoodooDoll && CanSpawnWoF)
            {
                CanSpawnWoF = false;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                    return;
                int num = self.stack;
                self.active = false;
                self.type = ItemID.None;
                self.stack = 0;
                bool flag = false;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].active && Main.npc[j].type == NPCID.Guide)
                    {
                        int num2 = -Main.npc[j].direction;
                        Main.BestiaryTracker.Kills.RegisterKill(Main.npc[j]);
                        Main.npc[j].SimpleStrikeNPC(9999, -num2, knockBack: 10f, noPlayerInteraction: true);
                        num--;
                        flag = true;
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, j, 9999f, 10f, -num2);
                        NPC.SpawnWOF(self.position);
                    }
                }
                if (flag)
                {
                    List<int> list = new List<int>();
                    for (int k = 0; k < 200; k++)
                    {
                        if (num <= 0)
                            break;
                        NPC nPC = Main.npc[k];
                        if (nPC.active && nPC.isLikeATownNPC)
                            list.Add(k);
                    }
                    while (num > 0 && list.Count > 0)
                    {
                        int index = Main.rand.Next(list.Count);
                        int num3 = list[index];
                        list.RemoveAt(index);
                        int num4 = -Main.npc[num3].direction;
                        if (Main.npc[num3].IsNPCValidForBestiaryKillCredit())
                            Main.BestiaryTracker.Kills.RegisterKill(Main.npc[num3]);
                        if (Main.npc[num3].active && !Main.npc[num3].townNPC && !Main.npc[num3].isLikeATownNPC && !NPCID.Sets.IsTownPet[num3]) // For some reason the For loop above add all Town NPCs to a list then kill em if you drop more than one Guide Voodoo Doll (It is a known glitch), i fixed it here
                            Main.npc[num3].SimpleStrikeNPC(9999, -num4, knockBack: 10f, noPlayerInteraction: true);
                        num--;
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, num3, 9999f, 10f, -num4);
                    }
                }
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, i);
            }
            else if (self.playerIndexTheItemIsReservedFor == Main.myPlayer && self.rare == ItemRarityID.White && self.type >= ItemID.None && !ItemID.Sets.IsLavaImmuneRegardlessOfRarity[self.type])
            {
                if (self.type != ItemID.GuideVoodooDoll || CanSpawnWoF)
                {
                    self.active = false;
                    self.type = ItemID.None;
                    self.stack = 0;
                }
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, i);
            }
        }
    }
    public class GuideVoodooDollTweak2 : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type is ItemID.GuideVoodooDoll;
        }
        public override void OnSpawn(Item item, IEntitySource source)
        {
            if (source.Context == "ThrowItem")
                GuideVoodooDollTweak.CanSpawnWoF = true;
        }
    }
}
