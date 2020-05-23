using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace FrozenAge.Projectiles
{
    class BloodDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 30;
			projectile.timeLeft = 1000;
			projectile.penetrate = 1;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
        }

        public override void AI()
        {
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X)+1.57f;
			
            Vector2 dustPosition = projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
			Dust dust = Dust.NewDustPerfect(dustPosition,  183, null, 100, Color.White, 1.5f);
			dust.velocity *= 1f;
			dust.noGravity = true;
			
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.45f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 720); 
			Main.player[projectile.owner].statLife += 3;//Main.rand.Next(1,4);
			
			Player player = Main.player[projectile.owner];
			float positionY = player.position.Y-50;
			float numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
				float positionX = player.position.X+Main.rand.Next(-25,25);
                Projectile.NewProjectile(positionX, positionY, 0, 0, ModContent.ProjectileType<BloodSeeker>(), (int) (damage * 2), knockback, player.whoAmI);
			}
		}
    }
}