using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.UI
{
    public class SellAndTrashTweak : ModPlayer // I hate how limited and brokey Smart Trash is and also how only when you are selling stuff, the Shift + Left-Click isn't the key you use to insta-move the item to the inventory (Chests and whatnot works like this) so i created a key to delete stuff (Delete) and when in a shop inventory, Shift + Left-Clicking insta-sell stuff. Only works correctly when Smart Trash is disabled
    {
        public override bool ShiftClickSlot(Item[] inventory, int context, int slot)
        {
            if (inventory[slot].type <= ItemID.None)
                return base.ShiftClickSlot(inventory, context, slot);
            if (Main.npcShop > 0 && !inventory[slot].favorited && context != 15)
            {
                Chest chest = Main.instance.shop[Main.npcShop];
                Player player = Main.player[Main.myPlayer];
                if ((inventory[slot].type < ItemID.CopperCoin || inventory[slot].type > ItemID.PlatinumCoin) && PlayerLoader.CanSellItem(player, player.TalkNPC, chest.item, inventory[slot]))
                {
                    if (player.SellItem(inventory[slot]))
                    {
                        Terraria.UI.ItemSlot.AnnounceTransfer(new Terraria.UI.ItemSlot.ItemTransferInfo(inventory[slot], context, 15));
                        int soldItemIndex = chest.AddItemToShop(inventory[slot]);
                        inventory[slot].TurnToAir();
                        SoundEngine.PlaySound(SoundID.Coins);
                        Recipe.FindRecipes();
                        PlayerLoader.PostSellItem(player, player.TalkNPC, chest.item, chest.item[soldItemIndex]);
                    }
                    else if (inventory[slot].value == 0)
                    {
                        Terraria.UI.ItemSlot.AnnounceTransfer(new Terraria.UI.ItemSlot.ItemTransferInfo(inventory[slot], context, 15));
                        int soldItemIndex = chest.AddItemToShop(inventory[slot]);
                        inventory[slot].TurnToAir();
                        SoundEngine.PlaySound(SoundID.Grab);
                        Recipe.FindRecipes();
                        PlayerLoader.PostSellItem(player, player.TalkNPC, chest.item, chest.item[soldItemIndex]);
                    }
                }
            }
            return base.ShiftClickSlot(inventory, context, slot);
        }
        public override bool HoverSlot(Item[] inventory, int context, int slot)
        {
            if (inventory[slot].type <= ItemID.None)
                return base.HoverSlot(inventory, context, slot);
            if (Terraria.UI.ItemSlot.ShiftInUse)
            {
                Item item = inventory[slot];
                bool flag2 = false;
                if (Main.LocalPlayer.tileEntityAnchor.IsInValidUseTileEntity())
                {
                    flag2 = Main.LocalPlayer.tileEntityAnchor.GetTileEntity().OverrideItemSlotHover(inventory, context, slot);
                }
                if (item.type > ItemID.None && item.stack > 0 && !inventory[slot].favorited && !flag2)
                {
                    if (Main.npcShop > 0 && !item.favorited && context != 15)
                    {
                        Main.cursorOverride = 10;
                    }
                }
            }
            if (ReiKeybinds.TrashKey.JustPressed || ReiKeybinds.TrashKey.Current)
            {
                if (!inventory[slot].favorited && context != 15)
                {
                    Player player = Main.player[Main.myPlayer];
                    SoundEngine.PlaySound(SoundID.Grab);
                    player.trashItem = inventory[slot].Clone();
                    Terraria.UI.ItemSlot.AnnounceTransfer(new Terraria.UI.ItemSlot.ItemTransferInfo(player.trashItem, context, 6));
                    inventory[slot].TurnToAir();
                    if (context == 3 && Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendData(MessageID.SyncChestItem, -1, -1, null, player.chest, slot);
                    }
                    Recipe.FindRecipes();
                }
            }
            return base.HoverSlot(inventory, context, slot);
        }
    }
}