using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.NPCs.Boss
{
	public class PineNeedles : ModProjectile
	{
		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = ProjectileID.Bullet;
			projectile.timeLeft = 1000;
			projectile.penetrate = 1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
		}
	}
}
