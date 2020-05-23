using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FrozenAge.Projectiles
{
    class FrostBlast : ModProjectile
    {
		public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.InfernoFriendlyBlast);
            aiType = ProjectileID.InfernoFriendlyBlast;
			projectile.friendly = true;
        }
		
		public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.InfernoFriendlyBlast; } }

		public override bool PreKill(int timeLeft) {
			projectile.type = ProjectileID.InfernoFriendlyBlast;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Frostburn, 600);
			if (Main.dayTime == false)
			{
				target.AddBuff(BuffID.CursedInferno, 600);
				target.AddBuff(BuffID.Ichor, 600);
			}
		}
    }
}