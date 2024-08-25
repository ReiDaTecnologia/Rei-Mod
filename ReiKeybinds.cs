using Terraria.ModLoader;

namespace ReiMod
{
    public class ReiKeybinds : ModSystem // All my mod's keybinds
    {
        public static ModKeybind LightPetUpKey { get; private set; }
        public static ModKeybind LightPetDownKey { get; private set; }
        public static ModKeybind LightPetLeftKey { get; private set; }
        public static ModKeybind LightPetRightKey { get; private set; }
        public static ModKeybind TrashKey { get; private set; }

        public override void Load()
        {
            LightPetUpKey = KeybindLoader.RegisterKeybind(Mod, "LightPetUp", "Up");
            LightPetDownKey = KeybindLoader.RegisterKeybind(Mod, "LightPetDown", "Down");
            LightPetLeftKey = KeybindLoader.RegisterKeybind(Mod, "LightPetLeft", "Left");
            LightPetRightKey = KeybindLoader.RegisterKeybind(Mod, "LightPetRight", "Right");
            TrashKey = KeybindLoader.RegisterKeybind(Mod, "Trash", "Delete");
        }

        public override void Unload()
        {
            LightPetUpKey = null;
            LightPetDownKey = null;
            LightPetLeftKey = null;
            LightPetRightKey = null;
            TrashKey = null;
        }
    }
}
