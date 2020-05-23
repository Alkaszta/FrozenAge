using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Weapons.Ranged.FrozenIgnition
{
	public class FrozenFlame : ModProjectile
	{
        public override void SetDefaults()
        {
			projectile.width = 6;
			projectile.height = 6;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.extraUpdates = 3;
        }
 
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.45f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
            if (projectile.timeLeft > 100)
            {
                projectile.timeLeft = 100;
            }
            if (projectile.ai[0] > 8f)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 4f);
                    Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 2f);
					int dust3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.velocity.X * 0.75f, projectile.velocity.Y * 0.75f, 130, default(Color), 1f);
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
			return;
        }
 
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 500);
        }
 
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}