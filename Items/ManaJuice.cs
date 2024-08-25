using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class ManaJuice : ModItem // An idea i had for Mana Fruit Mod. Give the mana needed to use the magic item if you don't have enough, 10 seconds cooldown. This item don't exist if Mana Fruit Mod isn't installed
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 26;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 45;
            Item.UseSound = SoundID.Item92;
            Item.useAnimation = 45;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(gold: 4);
        }

        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<ReiPlayer>().UsedManaJuice;
        }

        public override bool? UseItem(Player player)
        {
            var ManaJuice = player.GetModPlayer<ReiPlayer>();
            if (ManaJuice.UsedManaJuice)
                return null;
            ManaJuice.UsedManaJuice = true;
            return true;
        }
    }
}
