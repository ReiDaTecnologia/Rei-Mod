using ReiMod.Items;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod
{
    public class ReiRecipes : ModSystem // All my recipes
    {
        public override void Load()
        {
            Terraria.On_Item.GetShimmered += ShimmerTransmutationWithConditions;
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup TierFourOreBroadsword = new RecipeGroup(() => Lang.misc[37] + " Tier Four Ore Broadsword", new int[] // Recipe group used for the alternative Flymeal recipe
            {
                    ItemID.GoldBroadsword,
                    ItemID.PlatinumBroadsword
            });

            RecipeGroup.RegisterGroup("Any Tier Four Ore Broadsword", TierFourOreBroadsword);

            RecipeGroup AnyInfiniteFlightMount = new RecipeGroup(() => Lang.misc[37] + " Classic Mode Infinite Flight Mount", new int[] // Used for Soaring Insignia for Classic Mode/Journey Mode recipe
            {
                    ItemID.CosmicCarKey,
                    ItemID.DrillContainmentUnit
            });

            RecipeGroup.RegisterGroup("Any Classic Mode Infinite Flight Mount", AnyInfiniteFlightMount);

            RecipeGroup AnyEarlyHardmodeWing = new RecipeGroup(() => Lang.misc[37] + " Early Hardmode Wing", new int[] // Used for Soaring Insignia for Classic Mode/Journey Mode recipe
            {
                    ItemID.AngelWings,
                    ItemID.DemonWings
            });

            RecipeGroup.RegisterGroup("Any Early Hardmode Wing", AnyEarlyHardmodeWing);

            RecipeGroup IronOre = new RecipeGroup(() => Lang.misc[37] + " Iron Ore", new int[] // Used for the Magnet Potion recipe
{
                    ItemID.IronOre,
                    ItemID.LeadOre
});

            RecipeGroup.RegisterGroup("Any Iron Ore", IronOre);
        }
        public override void AddRecipes()
        {

            Recipe.Create(ItemID.GoldChest) // Add a recipe for Gold Chest as it is my fav storage chest type and i hate how it doesn't have a recipe
                .AddIngredient(ItemID.GoldBar, 8)
                .AddRecipeGroup("IronBar", 2)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ItemID.EmpressFlightBooster) // I would like to have infinite flight in Classic Mode/Journey Mode too so i decided to create a recipe for it. It doesn't exist in Expert or Master Mode as you can get it in there
                .AddIngredient(ItemID.CreativeWings)
                .AddIngredient(ItemID.SpookyWings)
                .AddIngredient(ItemID.FestiveWings)
                .AddRecipeGroup("Any Classic Mode Infinite Flight Mount")
                .AddRecipeGroup("Any Early Hardmode Wing")
                .AddIngredient(ItemID.SoulofFlight, 100)
                .AddCondition(Condition.InSpace)
                .AddCondition(Condition.NearWater)
                .AddCondition(Condition.NearLava)
                .AddCondition(Condition.NearHoney)
                .AddCondition(Condition.NearShimmer)
                .AddCondition(Condition.InClassicMode)
                .AddTile(TileID.CrystalBall)
                .Register();

            Recipe.Create(ItemID.WaterBucket) // You can fill Bottles using Sinks but you can't fill Water Buckets from sinks? Inconsistence fixed
                .AddIngredient(ItemID.EmptyBucket)
                .AddCondition(Condition.NearWater)
                .Register();

            Recipe.Create(ItemID.Flymeal) // Alternative Flymeal recipe because stinkbug is a pain to get
                .AddRecipeGroup("Any Tier Four Ore Broadsword")
                .AddIngredient(ItemID.StinkPotion)
                .AddCondition(Condition.NearHoney)
                .Register();

            Recipe.Create(ModContent.ItemType<AngelBlock>()) // Angel Block's recipe
                .AddIngredient(ItemID.StoneBlock)
                .AddIngredient(ItemID.GiantHarpyFeather)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ModContent.ItemType<AngelWall>()) // Angel Wall's recipe
                .AddIngredient(ItemID.StoneBlock)
                .AddIngredient(ItemID.GiantHarpyFeather)
                .AddTile(TileID.WorkBenches)
                .Register();

            Recipe.Create(ModContent.ItemType<AngelWall>()) // Angel Wall and Angel Block is interchangeable
                .AddIngredient(ModContent.ItemType<AngelBlock>())
                .Register();

            Recipe.Create(ModContent.ItemType<AngelBlock>()) // Angel Block and Angel Wall is interchangeable
                .AddIngredient(ModContent.ItemType<AngelWall>())
                .Register();

            Recipe.Create(ItemID.AdamantiteForge) // Why you can't craft Adamantite Forge with bars when bars are just the processed version of the ore? weirdness fixed
                .AddIngredient(ItemID.AdamantiteBar, 7)
                .AddIngredient(ItemID.Hellforge)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ItemID.TitaniumForge) // Why you can't craft Titanium Forge with bars when bars are just the processed version of the ore? weirdness fixed
                .AddIngredient(ItemID.TitaniumBar, 7)
                .AddIngredient(ItemID.Hellforge)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            Recipe.Create(ItemID.GreaterHealingPotion) // Lesser Healing Potion are used to craft the Healing Potion and Greater Healing Potion is used to craft Super Healing Potion. Why the Healing Potion aren't used to craft the Greater Healing Potion? Inconsistence fixed
                .AddIngredient(ItemID.HealingPotion)
                .AddIngredient(ItemID.PixieDust, 3)
                .AddIngredient(ItemID.CrystalShard)
                .AddTile(TileID.Bottles)
                .Register();

            // The recipe below are for the Height Fixed Statues, they are just a conversion recipe from the normal statues
            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Anvil>())
                .AddIngredient(ItemID.AnvilStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.AnvilStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Anvil>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Bat>())
                .AddIngredient(ItemID.BatStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.BatStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Bat>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Bird>())
                .AddIngredient(ItemID.BirdStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.BirdStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Bird>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Buggy>())
                .AddIngredient(ItemID.BuggyStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.BuggyStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Buggy>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Fish>())
                .AddIngredient(ItemID.FishStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.FishStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Fish>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Frog>())
                .AddIngredient(ItemID.FrogStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.FrogStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Frog>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Mouse>())
                .AddIngredient(ItemID.MouseStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.MouseStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Mouse>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Piranha>())
                .AddIngredient(ItemID.PiranhaStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.PiranhaStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Piranha>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();


            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Shark>())
                .AddIngredient(ItemID.SharkStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.SharkStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Shark>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Snail>())
                .AddIngredient(ItemID.SnailStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.SnailStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Snail>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Turtle>())
                .AddIngredient(ItemID.TurtleStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.TurtleStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Turtle>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<HeightFixedStatues_Worm>())
                .AddIngredient(ItemID.WormStatue)
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ItemID.WormStatue)
                .AddIngredient(ModContent.ItemType<HeightFixedStatues_Worm>())
                .AddTile(TileID.HeavyWorkBench)
                .Register();

            Recipe.Create(ModContent.ItemType<MagnetPotion>()) // Magnet Potion's recipe
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.RockLobster)
                .AddRecipeGroup("Any Iron Ore")
                .AddTile(TileID.Bottles)
                .Register();
        }
        public override void SetStaticDefaults()
        {
            if (ModContent.TryFind("ManaFruit", "ManaFruit", out ModItem ManaFruit)) // Mana Juice's recipe. This recipe don't exist if Mana Fruit Mod isn't installed
            {
                ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<ManaJuice>()] = ManaFruit.Type;
                ItemID.Sets.ShimmerTransformToItem[ManaFruit.Type] = ModContent.ItemType<ManaJuice>();
            }
            ItemID.Sets.ShimmerTransformToItem[ItemID.LifeFruit] = ModContent.ItemType<LifeJuice>(); // Life Juice's recipe
            // Corruption World/Crimson World exclusive item shimmer transmutation loop
            ItemID.Sets.ShimmerTransformToItem[ItemID.DemoniteOre] = ItemID.CrimtaneOre;
            ItemID.Sets.ShimmerTransformToItem[ItemID.CrimtaneOre] = ItemID.DemoniteOre;
            ItemID.Sets.ShimmerTransformToItem[ItemID.TissueSample] = ItemID.ShadowScale;
            ItemID.Sets.ShimmerTransformToItem[ItemID.ShadowScale] = ItemID.TissueSample;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Ebonkoi] = ItemID.Hemopiranha;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Hemopiranha] = ItemID.Ebonkoi;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Ichor] = ItemID.CursedFlame;
            ItemID.Sets.ShimmerTransformToItem[ItemID.CursedFlame] = ItemID.Ichor;
            // Instead of crafting the Biome Chests (that is for decoration purposes only) from the expensive and hard-to-obtain Biome Keys using Shimmer, you can transmute loop the keys to other keys. The Biome Chests are instead shimmer transmuted from their biome "normal" chests
            ItemID.Sets.ShimmerTransformToItem[ItemID.JungleKey] = ItemID.CorruptionKey;
            ItemID.Sets.ShimmerTransformToItem[ItemID.CorruptionKey] = ItemID.CrimsonKey;
            ItemID.Sets.ShimmerTransformToItem[ItemID.CrimsonKey] = ItemID.HallowedKey;
            ItemID.Sets.ShimmerTransformToItem[ItemID.HallowedKey] = ItemID.FrozenKey;
            ItemID.Sets.ShimmerTransformToItem[ItemID.FrozenKey] = ItemID.DungeonDesertKey;
            ItemID.Sets.ShimmerTransformToItem[ItemID.DungeonDesertKey] = ItemID.JungleKey;
            ItemID.Sets.ShimmerTransformToItem[ItemID.IvyChest] = ItemID.JungleChest;
            ItemID.Sets.ShimmerTransformToItem[ItemID.EbonwoodChest] = ItemID.CorruptionChest;
            ItemID.Sets.ShimmerTransformToItem[ItemID.ShadewoodChest] = ItemID.CrimsonChest;
            ItemID.Sets.ShimmerTransformToItem[ItemID.PearlwoodChest] = ItemID.HallowedChest;
            ItemID.Sets.ShimmerTransformToItem[ItemID.IceChest] = ItemID.FrozenChest;
            ItemID.Sets.ShimmerTransformToItem[ItemID.DesertChest] = ItemID.DungeonDesertChest;
            // I hate RNG so i added transmutation loops for several RNG-based loot items. Expert Mode or Master Mode exclusive loot only appear in the transmutation loop if you are in an Expert Mode or Master Mode
            ItemID.Sets.ShimmerTransformToItem[ItemID.BrokenBatWing] = ItemID.MoonStone;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MoonStone] = ItemID.BrokenBatWing;
            ItemID.Sets.ShimmerTransformToItem[ItemID.GolemMask] = ItemID.Picksaw;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Picksaw] = ItemID.Stynger;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Stynger] = ItemID.PossessedHatchet;
            ItemID.Sets.ShimmerTransformToItem[ItemID.PossessedHatchet] = ItemID.SunStone;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SunStone] = ItemID.EyeoftheGolem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.EyeoftheGolem] = ItemID.HeatRay;
            ItemID.Sets.ShimmerTransformToItem[ItemID.HeatRay] = ItemID.StaffofEarth;
            ItemID.Sets.ShimmerTransformToItem[ItemID.StaffofEarth] = ItemID.GolemFist;
            ItemID.Sets.ShimmerTransformToItem[ItemID.GolemFist] = ItemID.GolemPetItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.GolemPetItem] = ItemID.ShinyStone;
            ItemID.Sets.ShimmerTransformToItem[ItemID.ShinyStone] = ItemID.GolemMask;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SpookyHook] = ItemID.SpookyTwig;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SpookyTwig] = ItemID.StakeLauncher;
            ItemID.Sets.ShimmerTransformToItem[ItemID.StakeLauncher] = ItemID.CursedSapling;
            ItemID.Sets.ShimmerTransformToItem[ItemID.CursedSapling] = ItemID.NecromanticScroll;
            ItemID.Sets.ShimmerTransformToItem[ItemID.NecromanticScroll] = ItemID.SpookyWoodMountItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SpookyWoodMountItem] = ItemID.WitchBroom;
            ItemID.Sets.ShimmerTransformToItem[ItemID.WitchBroom] = ItemID.SpookyHook;
            ItemID.Sets.ShimmerTransformToItem[ItemID.BossMaskBetsy] = ItemID.BetsyWings;
            ItemID.Sets.ShimmerTransformToItem[ItemID.BetsyWings] = ItemID.DD2BetsyBow;
            ItemID.Sets.ShimmerTransformToItem[ItemID.DD2BetsyBow] = ItemID.MonkStaffT3;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MonkStaffT3] = ItemID.ApprenticeStaffT3;
            ItemID.Sets.ShimmerTransformToItem[ItemID.ApprenticeStaffT3] = ItemID.DD2SquireBetsySword;
            ItemID.Sets.ShimmerTransformToItem[ItemID.DD2SquireBetsySword] = ItemID.DD2BetsyPetItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.DD2BetsyPetItem] = ItemID.BossMaskBetsy;
            ItemID.Sets.ShimmerTransformToItem[ItemID.FairyQueenMagicItem] = ItemID.PiercingStarlight;
            ItemID.Sets.ShimmerTransformToItem[ItemID.PiercingStarlight] = ItemID.RainbowWhip;
            ItemID.Sets.ShimmerTransformToItem[ItemID.RainbowWhip] = ItemID.FairyQueenRangedItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.FairyQueenRangedItem] = ItemID.FairyQueenMask;
            ItemID.Sets.ShimmerTransformToItem[ItemID.FairyQueenMask] = ItemID.RainbowWings;
            ItemID.Sets.ShimmerTransformToItem[ItemID.RainbowWings] = ItemID.SparkleGuitar;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SparkleGuitar] = ItemID.RainbowCursor;
            ItemID.Sets.ShimmerTransformToItem[ItemID.RainbowCursor] = ItemID.HallowBossDye;
            ItemID.Sets.ShimmerTransformToItem[ItemID.HallowBossDye] = ItemID.FairyQueenPetItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.FairyQueenPetItem] = ItemID.EmpressFlightBooster;
            ItemID.Sets.ShimmerTransformToItem[ItemID.EmpressFlightBooster] = ItemID.FairyQueenMagicItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.BossMaskMoonlord] = ItemID.Meowmere;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Meowmere] = ItemID.Terrarian;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Terrarian] = ItemID.StarWrath;
            ItemID.Sets.ShimmerTransformToItem[ItemID.StarWrath] = ItemID.SDMG;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SDMG] = ItemID.Celeb2;
            ItemID.Sets.ShimmerTransformToItem[ItemID.Celeb2] = ItemID.LastPrism;
            ItemID.Sets.ShimmerTransformToItem[ItemID.LastPrism] = ItemID.LunarFlareBook;
            ItemID.Sets.ShimmerTransformToItem[ItemID.LunarFlareBook] = ItemID.RainbowCrystalStaff;
            ItemID.Sets.ShimmerTransformToItem[ItemID.RainbowCrystalStaff] = ItemID.MoonlordTurretStaff;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MoonlordTurretStaff] = ItemID.PortalGun;
            ItemID.Sets.ShimmerTransformToItem[ItemID.PortalGun] = ItemID.MeowmereMinecart;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MeowmereMinecart] = ItemID.MoonLordPetItem;
            ItemID.Sets.ShimmerTransformToItem[ItemID.MoonLordPetItem] = ItemID.GravityGlobe;
            ItemID.Sets.ShimmerTransformToItem[ItemID.GravityGlobe] = ItemID.SuspiciousLookingTentacle;
            ItemID.Sets.ShimmerTransformToItem[ItemID.SuspiciousLookingTentacle] = ItemID.LongRainbowTrailWings;
            ItemID.Sets.ShimmerTransformToItem[ItemID.LongRainbowTrailWings] = ItemID.BossMaskMoonlord;
            // I hate the fact some ore tools and whatnot is better than their counterpart so i added an Extractinator pre-hardmode recipe for them
            ItemID.Sets.ExtractinatorMode[ItemID.TinOre] = ItemID.TinOre;
            ItemID.Sets.ExtractinatorMode[ItemID.CopperOre] = ItemID.CopperOre;
            ItemID.Sets.ExtractinatorMode[ItemID.LeadOre] = ItemID.LeadOre;
            ItemID.Sets.ExtractinatorMode[ItemID.IronOre] = ItemID.IronOre;
            ItemID.Sets.ExtractinatorMode[ItemID.TungstenOre] = ItemID.TungstenOre;
            ItemID.Sets.ExtractinatorMode[ItemID.SilverOre] = ItemID.SilverOre;
            ItemID.Sets.ExtractinatorMode[ItemID.PlatinumOre] = ItemID.PlatinumOre;
            ItemID.Sets.ExtractinatorMode[ItemID.GoldOre] = ItemID.GoldOre;
        }

        private void ShimmerTransmutationWithConditions(On_Item.orig_GetShimmered orig, Item self) // Used for the shimmer loot transmutation loop so Expert Mode or Master Mode exclusive items only appear if you are in an Expert Mode or Master Mode world
        {
            if (self.type == ItemID.GolemFist || self.type == ItemID.NecromanticScroll || self.type == ItemID.DD2SquireBetsySword || self.type == ItemID.HallowBossDye || self.type == ItemID.MeowmereMinecart)
            {
                int num69 = self.stack;
                if (Main.masterMode)
                {
                    if (self.type == ItemID.GolemFist)
                        self.SetDefaults(ItemID.GolemPetItem);
                    if (self.type == ItemID.NecromanticScroll)
                        self.SetDefaults(ItemID.SpookyWoodMountItem);
                    if (self.type == ItemID.DD2SquireBetsySword)
                        self.SetDefaults(ItemID.DD2BetsyPetItem);
                    if (self.type == ItemID.HallowBossDye)
                        self.SetDefaults(ItemID.FairyQueenPetItem);
                    if (self.type == ItemID.MeowmereMinecart)
                        self.SetDefaults(ItemID.MoonLordPetItem);
                }  
                else if (Main.expertMode && !Main.masterMode)
                {
                    if (self.type == ItemID.GolemFist)
                        self.SetDefaults(ItemID.ShinyStone);
                    if (self.type == ItemID.NecromanticScroll)
                        self.SetDefaults(ItemID.WitchBroom);
                    if (self.type == ItemID.DD2SquireBetsySword)
                        self.SetDefaults(ItemID.BossMaskBetsy);
                    if (self.type == ItemID.HallowBossDye)
                        self.SetDefaults(ItemID.EmpressFlightBooster);
                    if (self.type == ItemID.MeowmereMinecart)
                        self.SetDefaults(ItemID.GravityGlobe);
                }
                else
                {
                    if (self.type == ItemID.GolemFist)
                        self.SetDefaults(ItemID.GolemMask);
                    if (self.type == ItemID.NecromanticScroll)
                        self.SetDefaults(ItemID.SpookyHook);
                    if (self.type == ItemID.DD2SquireBetsySword)
                        self.SetDefaults(ItemID.BossMaskBetsy);
                    if (self.type == ItemID.HallowBossDye)
                        self.SetDefaults(ItemID.FairyQueenMagicItem);
                    if (self.type == ItemID.MeowmereMinecart)
                        self.SetDefaults(ItemID.BossMaskMoonlord);
                }
                self.stack = num69;
                self.shimmered = true;
                Item.ShimmerEffect(self.Center);
            }
            else
                orig(self);
        }

        public override void PostAddRecipes() // Used to remove the Biome Key to Biome Chest shimmer transmutation recipes
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if ((recipe.HasResult(ItemID.JungleChest) || recipe.HasResult(ItemID.CorruptionChest) || recipe.HasResult(ItemID.CrimsonChest) || recipe.HasResult(ItemID.HallowedChest) || recipe.HasResult(ItemID.FrozenChest) || recipe.HasResult(ItemID.DesertChest)) && (recipe.HasIngredient(ItemID.JungleKey) || recipe.HasIngredient(ItemID.CorruptionKey) || recipe.HasIngredient(ItemID.CrimsonKey)) || recipe.HasIngredient(ItemID.HallowedKey) || recipe.HasIngredient(ItemID.FrozenKey) || recipe.HasIngredient(ItemID.DungeonDesertKey))
                    recipe.DisableRecipe();
            }
                base.PostAddRecipes();
        }
    }
    public class ReiExtractinatorRecipes : GlobalItem // Used in conjuction with the ItemID.Sets.ExtractinatorMode above
    {
        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (extractType == ItemID.TinOre)
            {
                resultStack = 1;
                resultType = ItemID.CopperOre;
            }

            if (extractType == ItemID.CopperOre)
            {
                resultStack = 1;
                resultType = ItemID.TinOre;
            }

            if (extractType == ItemID.LeadOre)
            {
                resultStack = 1;
                resultType = ItemID.IronOre;
            }

            if (extractType == ItemID.IronOre)
            {
                resultStack = 1;
                resultType = ItemID.LeadOre;
            }

            if (extractType == ItemID.TungstenOre)
            {
                resultStack = 1;
                resultType = ItemID.SilverOre;
            }

            if (extractType == ItemID.SilverOre)
            {
                resultStack = 1;
                resultType = ItemID.TungstenOre;
            }

            if (extractType == ItemID.PlatinumOre)
            {
                resultStack = 1;
                resultType = ItemID.GoldOre;
            }

            if (extractType == ItemID.GoldOre)
            {
                resultStack = 1;
                resultType = ItemID.PlatinumOre;
            }
        }
    }
}