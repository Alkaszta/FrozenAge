using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FrozenAge.NPCs.Boss
{
	[AutoloadBossHead]
	public class SnowPumpkMan : ModNPC
    {
        private Player player;

        public override void SetDefaults()
        {
            npc.aiStyle = 1; //Slime AI, i would like to know king slimes AI but this works just the same.
            npc.lifeMax = 13500;
            npc.damage = 30;
            npc.defense = 15;
            npc.knockBackResist = 0;
            npc.width = 250;
            npc.height = 146;
            animationType = NPCID.KingSlime; //Animation type.
            Main.npcFrameCount[npc.type] = 6; //The king slime has a frame count of 6.
            aiType = NPCID.KingSlime; //AI type
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
            music = MusicID.Boss2;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }
        
        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 18000;
            npc.damage = 48;
            npc.defense = 20;
        }

        private float moveSlime
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        private float attackSlam
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        private float attackRoll
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        private float attackRecovery
        {
            get => npc.ai[3];
            set => npc.ai[3] = value;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.noTileCollide = true;
                    npc.velocity = new Vector2(0f, 5f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }

            attackSlam -= 1f;
            if (Main.netMode != 1 && attackSlam <= 0f)
            {
                int dmg = 20;
                attackSlam = 150f + 150f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
                Vector2 delta = player.Center - npc.Center ;
                float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                if (magnitude > 0)
                {
                    delta *= 5f / magnitude;
                }
                else
                {
                    delta = new Vector2(0f, 5f);
                }
                
                if (npc.life >= npc.lifeMax / 2)
                {
					if (Main.expertMode)
					{
						dmg = dmg * 2;
					}
                    float numberProjectiles = 3;
                    float rotation = MathHelper.ToRadians(10);
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed = delta.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2.5f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SnowBoulder"), dmg, 5f, Main.myPlayer, 1000f);
                    }
                    npc.netUpdate = true;
                }
                if (npc.life <= npc.lifeMax / 2)
                {
                    dmg = 48;
					if (Main.expertMode)
					{
						dmg = dmg * 2;
					}
                    float numberProjectiles = 5;
                    float rotation = MathHelper.ToRadians(15);
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed = delta.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2.5f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SnowBoulder"), dmg, 5f, Main.myPlayer, 1000f);
                    }
                    npc.netUpdate = true;
                }
            }
            
            if (npc.life <= npc.lifeMax / 2)
            {
                bool runOnce = true;
                if (runOnce)
                {
                    if(Main.netMode != 1)
                    {
                        int npcHandCharge = NPC.NewNPC((int) npc.Center.X, (int) npc.Center.Y, mod.NPCType("HandCharge"));
                        Main.npc[npcHandCharge].netUpdate = true;
                        int npcHandShoot = NPC.NewNPC((int) npc.Center.X, (int) npc.Center.Y, mod.NPCType("HandShoot"));
                        Main.npc[npcHandShoot].netUpdate = true;
                    }
                    runOnce = false;
                }
                /*
                bool runOnce = true;
                if (runOnce)
                {
                    for (int h = 0; h < 2; h++)
                    {
                        if (Main.netMode != 1)
                        {
                            NPC.NewNPC((int) npc.Center.X, (int) npc.Center.Y, mod.NPCType("Hand"));
                        }
                    }
                    runOnce = false;
                }*/
            }
        }
    }
}