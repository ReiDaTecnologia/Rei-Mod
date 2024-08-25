using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class SummoningPotionTweak : GlobalBuff // Make the summoning potion also give an additional sentry slot
    {
        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            if (type == BuffID.Summoning)
                tip = "Increased max number of minions and sentries";
        }

        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.Summoning)
                player.maxTurrets += 1;
        }
    }

    public class ReiModSummoningPotionTweak2 : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.SummoningPotion;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int index = tooltips.FindIndex(static line => line.Text.Contains("Increases your max number of minions by 1"));
            if (index >= 0)
            {
                ref string text = ref tooltips[index].Text;
                text = text.Replace("Increases your max number of minions by 1", "Increases your max number of minions and sentries by 1");
            }
        }
    }
}
