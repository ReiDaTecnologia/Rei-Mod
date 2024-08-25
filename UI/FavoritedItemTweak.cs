using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.UI
{
    public class FavoritedItemTweak : ModPlayer // I hate how when you switch accessories and whatnot, they don't keep their previous favorited state so this somewhat fix it. Only works when left-clicking, doesn't work for right-click because i mostly use left-click when switching accessories and whatnot
    {
        public override void Load()
        {
            Terraria.UI.On_ItemSlot.EquipSwap += KeepItemFavorited;
            Terraria.UI.On_ItemSlot.LeftClick_ItemArray_int_int += KeepItemFavorited2;
            base.Load();
        }

        private Item KeepItemFavorited(Terraria.UI.On_ItemSlot.orig_EquipSwap orig, Item item, Item[] inv, int slot, out bool success)
        {
            success = false;
            _ = Main.player[Main.myPlayer];
#pragma warning disable CS1717 // Assignment made to same variable
            item.favorited = item.favorited;
#pragma warning restore CS1717 // Assignment made to same variable
            Item result = inv[slot].Clone();
            inv[slot] = item.Clone();
            SoundEngine.PlaySound(SoundID.Grab);
            Recipe.FindRecipes();
            success = true;
            return result;
        }

        public List<Item> FavoritedItems = new List<Item>();
        public Item item;
        public int Slot;
        public bool CanReFavoriteItem;
        public bool FavoritedItemIsBeingSwapped;

        private void KeepItemFavorited2(Terraria.UI.On_ItemSlot.orig_LeftClick_ItemArray_int_int orig, Item[] inv, int context, int slot)
        {
            if (((context >= 0 && context <= 2) || (context == 32)) && !FavoritedItems.Contains(inv[slot]) && inv[slot].favorited && !Main.keyState.IsKeyDown(Main.FavoriteKey) && (Main.mouseLeft && Main.mouseLeftRelease))
                FavoritedItems.Add(inv[slot]);
            if (((context >= 8 && context <= 12) || (context >= 16 && context <= 20) || (context == 33)) && FavoritedItems.Contains(Main.mouseItem) && (Main.mouseLeft && Main.mouseLeftRelease))
            {
                if (inv[slot].netID != 0)
                {
                    FavoritedItemIsBeingSwapped = true;
                    item = Main.mouseItem;
                }
                Slot = slot;
                CanReFavoriteItem = true;
                FavoritedItems.Remove(Main.mouseItem);
            }
            if (CanReFavoriteItem)
            {
                if (!inv[Slot].favorited || FavoritedItemIsBeingSwapped)
                {
                    inv[Slot].favorited = true;
                    if (FavoritedItemIsBeingSwapped)
                    {
                        if (inv[Slot] == item && inv[Slot].favorited)
                            FavoritedItemIsBeingSwapped = false;
                    }
                }
                else
                    CanReFavoriteItem = false;
            }
            orig(inv, context, slot);
        }
    }
}
