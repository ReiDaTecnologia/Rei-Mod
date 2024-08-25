using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReiMod.Projectiles
{
    public class LightPetTweaks : GlobalProjectile // I hate how the Light Pets become useless when they are inside of blocks (Their light are completely blocked off) so after i found out that Suspicious Looking Tentacle have a "fix" for it, i decided to give it to all the other light pets. I also replaced the Shadow Orb and Wisp in a Bottle's control keys to their own keys as using the player's control key is problematic imo
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type is ProjectileID.ShadowOrb or ProjectileID.CrimsonHeart or ProjectileID.MagicLantern or ProjectileID.BlueFairy or ProjectileID.PinkFairy or ProjectileID.GreenFairy or ProjectileID.DD2PetGhost or ProjectileID.Wisp or ProjectileID.PumpkingPet or ProjectileID.GolemPet or ProjectileID.FairyQueenPet; // Suspicious Looking Tentacle not included for the reason above and it also have no control keys
        }

        public override void AI(Projectile projectile)
        {
            if (Main.tile[(int)projectile.position.X / 16, (int)projectile.position.Y / 16].HasTile && !Main.player[projectile.owner].dead && Main.player[projectile.owner].active) // This is the Suspicious Looking Tentacle's code that mitigates the issue mentioned above
            {
                Player player11 = Main.player[projectile.owner];
                Vector3 v3_ = new Vector3(0.5f, 0.9f, 1f) * 2f;
                DelegateMethods.v3_1 = v3_;
                Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * 6f, 20f, DelegateMethods.CastLightOpen);
                Utils.PlotTileLine(projectile.Left, projectile.Right, 20f, DelegateMethods.CastLightOpen);
                Utils.PlotTileLine(player11.Center, player11.Center + player11.velocity * 6f, 40f, DelegateMethods.CastLightOpen);
                Utils.PlotTileLine(player11.Left, player11.Right, 40f, DelegateMethods.CastLightOpen);
            }
            if (projectile.type == ProjectileID.ShadowOrb)
            {
                projectile.rotation += 0.02f;
                if (projectile.type == 18 && Main.player[projectile.owner].lightOrb)
                {
                    projectile.timeLeft = 2;
                }
                if (!Main.player[projectile.owner].dead)
                {
                    float num115 = 3f;
                    Vector2 vector16 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num116 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector16.X;
                    float num117 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector16.Y;
                    int num118 = 800;
                    int num119 = 70;
                    if (projectile.type == 18)
                    {
                        if (ReiKeybinds.LightPetUpKey.Current)
                        {
                            num117 = Main.player[projectile.owner].position.Y - 40f - vector16.Y;
                            num116 -= 6f;
                            num119 = 4;
                        }
                        else if (ReiKeybinds.LightPetDownKey.Current)
                        {
                            num117 = Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height + 40f - vector16.Y;
                            num116 -= 6f;
                            num119 = 4;
                        }
                    }
                    float num120 = (float)Math.Sqrt(num116 * num116 + num117 * num117);
                    num120 = (float)Math.Sqrt(num116 * num116 + num117 * num117);
                    if (num120 > (float)num118)
                    {
                        projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
                        projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
                    }
                    else if (num120 > (float)num119)
                    {
                        float num121 = num120 - (float)num119;
                        num120 = num115 / num120;
                        num116 *= num120;
                        num117 *= num120;
                        projectile.velocity.X = num116;
                        projectile.velocity.Y = num117;
                    }
                    else
                    {
                        projectile.velocity.X = (projectile.velocity.Y = 0f);
                    }
                }
                else
                {
                    projectile.Kill();
                }
            }
            if (projectile.type == ProjectileID.Wisp) // For some reason, unlike the Shadow Orb, using this method and even On_hook don't perfectly replace the player control keys for their own keys as the Wisp only move when you are holding one of the original keys and there also other minor issues, perhaps completely replacing the code could fix it but i really don't know how i could do that or what causes these issues at all. Well it isn't the end of the world so #GoodEnough
            {
                float num49 = 0.2f;
                float num50 = 5f;
                projectile.tileCollide = false;
                Vector2 vector5 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num51 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector5.X;
                float num52 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].gfxOffY + (float)(Main.player[projectile.owner].height / 2) - vector5.Y;
                if (ReiKeybinds.LightPetLeftKey.Current)
                {
                    num51 -= 120f;
                }
                else if (ReiKeybinds.LightPetRightKey.Current)
                {
                    num51 += 120f;
                }
                if (ReiKeybinds.LightPetDownKey.Current)
                {
                    num52 += 120f;
                }
                else
                {
                    if (ReiKeybinds.LightPetUpKey.Current)
                    {
                        num52 -= 120f;
                    }
                    num52 -= 60f;
                }
                float num53 = (float)Math.Sqrt(num51 * num51 + num52 * num52);
                if (num53 > 1000f)
                {
                    projectile.position.X += num51;
                    projectile.position.Y += num52;
                }
                if (projectile.localAI[0] == 1f)
                {
                    if (num53 < 10f)
                    {
                        Player player2 = Main.player[projectile.owner];
                        if (Math.Abs(player2.velocity.X) + Math.Abs(player2.velocity.Y) < num50 && (player2.velocity.Y == 0f || (player2.mount.Active && player2.mount.CanFly())))
                        {
                            projectile.localAI[0] = 0f;
                        }
                    }
                    num50 = 12f;
                    if (num53 < num50)
                    {
                        projectile.velocity.X = num51;
                        projectile.velocity.Y = num52;
                    }
                    else
                    {
                        num53 = num50 / num53;
                        projectile.velocity.X = num51 * num53;
                        projectile.velocity.Y = num52 * num53;
                    }
                    if ((double)projectile.velocity.X > 0.5)
                    {
                        projectile.direction = -1;
                    }
                    else if ((double)projectile.velocity.X < -0.5)
                    {
                        projectile.direction = 1;
                    }
                    projectile.spriteDirection = projectile.direction;
                    projectile.rotation -= (0.2f + Math.Abs(projectile.velocity.X) * 0.025f) * (float)projectile.direction;
                    projectile.frameCounter++;
                    if (projectile.frameCounter > 3)
                    {
                        projectile.frame++;
                        projectile.frameCounter = 0;
                    }
                    if (projectile.frame < 5)
                    {
                        projectile.frame = 5;
                    }
                    if (projectile.frame > 9)
                    {
                        projectile.frame = 5;
                    }
                    for (int l = 0; l < 2; l++)
                    {
                        int num54 = Dust.NewDust(new Vector2(projectile.position.X + 3f, projectile.position.Y + 4f), 14, 14, DustID.UltraBrightTorch);
                        Main.dust[num54].velocity *= 0.2f;
                        Main.dust[num54].noGravity = true;
                        Main.dust[num54].scale = 1.25f;
                        Main.dust[num54].shader = GameShaders.Armor.GetSecondaryShader(Main.player[projectile.owner].cLight, Main.player[projectile.owner]);
                    }
                    return;
                }
                if (num53 > 200f)
                {
                    projectile.localAI[0] = 1f;
                }
                if ((double)projectile.velocity.X > 0.5)
                {
                    projectile.direction = -1;
                }
                else if ((double)projectile.velocity.X < -0.5)
                {
                    projectile.direction = 1;
                }
                projectile.spriteDirection = projectile.direction;
                if (num53 < 10f)
                {
                    projectile.velocity.X = num51;
                    projectile.velocity.Y = num52;
                    projectile.rotation = projectile.velocity.X * 0.05f;
                    if (num53 < num50)
                    {
                        projectile.position += projectile.velocity;
                        projectile.velocity *= 0f;
                        num49 = 0f;
                    }
                    projectile.direction = -Main.player[projectile.owner].direction;
                }
                num53 = num50 / num53;
                num51 *= num53;
                num52 *= num53;
                if (projectile.velocity.X < num51)
                {
                    projectile.velocity.X += num49;
                    if (projectile.velocity.X < 0f)
                    {
                        projectile.velocity.X *= 0.99f;
                    }
                }
                if (projectile.velocity.X > num51)
                {
                    projectile.velocity.X -= num49;
                    if (projectile.velocity.X > 0f)
                    {
                        projectile.velocity.X *= 0.99f;
                    }
                }
                if (projectile.velocity.Y < num52)
                {
                    projectile.velocity.Y += num49;
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y *= 0.99f;
                    }
                }
                if (projectile.velocity.Y > num52)
                {
                    projectile.velocity.Y -= num49;
                    if (projectile.velocity.Y > 0f)
                    {
                        projectile.velocity.Y *= 0.99f;
                    }
                }
                if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
                {
                    projectile.rotation = projectile.velocity.X * 0.05f;
                }
                projectile.frameCounter++;
                if (projectile.frameCounter > 3)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame > 4)
                {
                    projectile.frame = 0;
                }
                return;
            }
        }
    }
}