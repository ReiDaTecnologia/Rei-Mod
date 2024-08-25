using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class LifeJuice : ModItem // An idea i had. If the player's life go below 100, it will heal him back up, one minute cooldown
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
            Item.value = Item.sellPrice(gold: 2);
        }

        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<ReiPlayer>().UsedLifeJuice && player.ConsumedLifeFruit == Player.LifeFruitMax;
        }

        public override bool? UseItem(Player player)
        {
            var LifeJuice = player.GetModPlayer<ReiPlayer>();
            if (LifeJuice.UsedLifeJuice)
                return null;
            LifeJuice.UsedLifeJuice = true;
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int index = tooltips.FindIndex(static line => line.Text.Contains("One minute cooldown"));
            if (Main.LocalPlayer.ConsumedLifeFruit < Player.LifeFruitMax && index >= 0)
            {
                ref string text = ref tooltips[index].Text;
                text = text.Replace("One minute cooldown", "One minute cooldown" + "\n" + $"Can only be used after consuming {Player.LifeFruitMax} Life Fruits");
            }
            base.ModifyTooltips(tooltips);
        }
    }
}
