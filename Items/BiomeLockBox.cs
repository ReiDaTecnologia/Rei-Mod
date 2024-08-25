using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class BiomeLockBox : ModItem // Generally i don't like how having a corruption world make you unable to have Crimson-exclusive content so this item allow you have the Crimson Chest exclusive item even if you have a corruption world or vice-versa
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 22;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.Yellow;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.sellPrice(gold: 20);
        }

        public override bool CanRightClick()
        {
            if (NPC.downedPlantBoss && (Main.LocalPlayer.HasItem(ItemID.JungleKey) || Main.LocalPlayer.HasItem(ItemID.CorruptionKey) || Main.LocalPlayer.HasItem(ItemID.CrimsonKey)) || Main.LocalPlayer.HasItem(ItemID.HallowedKey) || Main.LocalPlayer.HasItem(ItemID.FrozenKey) || Main.LocalPlayer.HasItem(ItemID.DungeonDesertKey))
                return true;
            return false;
        }

        public override void RightClick(Player player)
        {
            var BiomeKeys = new int[6]
            {
                ItemID.JungleKey, ItemID.CorruptionKey, ItemID.CrimsonKey,
                ItemID.HallowedKey, ItemID.FrozenKey, ItemID.DungeonDesertKey
            };
            foreach(int BiomeKey in BiomeKeys)
            {
                if (!player.HasItem(BiomeKey))
                    BiomeKeys = BiomeKeys.Where(val => val != BiomeKey).ToArray();
            }
            switch (Main.rand.Next(BiomeKeys))
            {
                case ItemID.JungleKey:
                    player.QuickSpawnItem(player.GetSource_ItemUse(Item), ItemID.PiranhaGun);
                    player.ConsumeItem(ItemID.JungleKey);
                    break;
                case ItemID.CorruptionKey:
                    player.QuickSpawnItem(player.GetSource_ItemUse(Item), ItemID.ScourgeoftheCorruptor);
                    player.ConsumeItem(ItemID.CorruptionKey);
                    break;
                case ItemID.CrimsonKey:
                    player.QuickSpawnItem(player.GetSource_ItemUse(Item), ItemID.VampireKnives);
                    player.ConsumeItem(ItemID.CrimsonKey);
                    break;
                case ItemID.HallowedKey:
                    player.QuickSpawnItem(player.GetSource_ItemUse(Item), ItemID.RainbowGun);
                    player.ConsumeItem(ItemID.HallowedKey);
                    break;
                case ItemID.FrozenKey:
                    player.QuickSpawnItem(player.GetSource_ItemUse(Item), ItemID.StaffoftheFrostHydra);
                    player.ConsumeItem(ItemID.FrozenKey);
                    break;
                case ItemID.DungeonDesertKey:
                    player.QuickSpawnItem(player.GetSource_ItemUse(Item), ItemID.StormTigerStaff);
                    player.ConsumeItem(ItemID.DungeonDesertKey);
                    break;

            }
            base.RightClick(player);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int index = tooltips.FindIndex(static line => line.Text.Contains("Right click to open"));
            if (index >= 0)
            {
                ref string text = ref tooltips[index].Text;
                if (!NPC.downedPlantBoss)
                    text = text.Replace("Right click to open", "It has been cursed by a powerful Jungle creature");
                else
                    text = text.Replace("Right click to open", "Right click to open" + "\n" + "Consume a random biome key in the inventory and give the respective biome chest unique loot");

            }
            base.ModifyTooltips(tooltips);
        }
    }

    public class BiomeLockBox_GlobalItem : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.DungeonFishingCrateHard)
            {
                itemLoot.Add(ItemDropRule.ByCondition(Condition.DownedPlantera.ToDropCondition(ShowItemDropInUI.Always), ModContent.ItemType<BiomeLockBox>()));
            }
            base.ModifyItemLoot(item, itemLoot);
        }
    }
}
