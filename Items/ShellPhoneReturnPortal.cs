using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Items
{
    public class ShellPhoneReturnPortal : GlobalItem // An extension for Cellphone Portal that make all the ShellPhone's tp mode leave a return portal. As i did this before i learned On_hook, i used a hacky workaround but in theory you could use the On_hook to make it more correct but as it works great as-is, i decided to leave it in
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type is ItemID.ShellphoneSpawn or ItemID.ShellphoneOcean or ItemID.ShellphoneHell;
        }
        public override bool? UseItem(Item item, Player player)
        {
            player.PotionOfReturnOriginalUsePosition = player.Bottom;
            player.GetModPlayer<ReiPlayer>().AllowAnimationTime = true;
            player.GetModPlayer<ReiPlayer>().AnimationTime = 60;
            return base.UseItem(item, player);
        }
    }
}
