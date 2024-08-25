using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class DD2Tweak : GlobalItem // Even tho Monk Belt and Huntress Buckler are obtained in hardmode and dropped from harder minibosses, they give the same sentries bonus (1) and summon damage bonus (10%) as the pre-hardmode "easy" boss. I decided to double it as it just make more sense
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type is ItemID.MonkBelt or ItemID.HuntressBuckler;
        }
        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += 0.1f;
            player.maxTurrets++;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) // Changed the item's tooltips to reflect the changes
        {
            int index = tooltips.FindIndex(static line => line.Text.Contains("Increase your max number of sentries by 1"));
            if (index >= 0)
            {
                ref string text = ref tooltips[index].Text;
                text = text.Replace("Increase your max number of sentries by 1", "Increase your max number of sentries by 2");
            }
            index = tooltips.FindIndex(static line => line.Text.Contains("Increases summon damage by 10%"));
            if (index >= 0)
            {
                ref string text = ref tooltips[index].Text;
                text = text.Replace("Increases summon damage by 10%", "Increases summon damage by 20%");
            }
        }
    }
}
