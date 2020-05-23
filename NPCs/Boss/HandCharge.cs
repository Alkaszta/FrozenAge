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
using System.Collections.Specialized;

namespace FrozenAge.NPCs.Boss
{
	public class Methods
	{
		public static Vector2 PolarVector(float radius, float theta)
		{
			return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius;
		}
	}
	
	public class HandCharge : ModNPC
	{
		private Player player;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hand");
		}
		private float attackCharge
		{
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.width = 56;
			npc.height = 76;
			npc.damage = 25;
			npc.defense = 15;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.knockBackResist = 0;
		}
		
        NPC Body = null;
		bool runOnce = true;
		Vector2 flyTo;

		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			
			if (runOnce)
			{
				if (npc.ai[0] == 0)
				{
					npc.ai[0] = -1;
				}

				runOnce = false;
			}

			if (npc.ai[0] == -1)
			{
				for (int n = 0; n < 200; n++)
				{
					if (Main.npc[n].type == mod.NPCType("SnowPumpkMan") && Main.npc[n].active)
					{
						npc.ai[0] = n;
						break;
					}
				}
			}

			if (npc.ai[0] != -1 || Main.npc[(int)npc.ai[0]].type != mod.NPCType("SnowPumpkMan"))
			{
				Body = Main.npc[(int)npc.ai[0]];
				int handCount = 0;
				int whichHandAmI = 0;
				for (int n = 0; n < 1; n++)
				{
					if (Main.npc[n].type == mod.NPCType("Hand") && Main.npc[n].active && Main.npc[n].ai[0] == npc.ai[0])
					{
						if (Main.npc[n].Center.X < npc.Center.X || (Main.npc[n].Center.X == npc.Center.X && n < npc.whoAmI))
						{
							whichHandAmI++;
						}
						handCount++;
					}
				}

				Vector2 offSet = Methods.PolarVector(200, 75);
				offSet.X *= 1f;

				flyTo = Body.Center + offSet;
				npc.velocity = (flyTo - npc.Center) * .1f;

				while (attackCharge <= 0f)
				{
					Vector2 delta = player.Center - npc.Center;
					float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
					delta *= 10f / magnitude;
					npc.velocity = delta;
					npc.ai[1] = 500f;
				}
				attackCharge -= 1f;

				if (!Body.active || Body.type != mod.NPCType("SnowPumpkMan"))
				{
					npc.life = 0;
					npc.checkDead();
				}
			}

			else
			{
				npc.life = 0;
				npc.checkDead();
			}
		}
	}
}