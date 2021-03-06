using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Projectiles
{
	public class CrystalArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Arrow");
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 2;
			projectile.timeLeft = 600;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
			aiType = ProjectileID.WoodenArrowFriendly;
		}
		public override bool PreKill(int timeLeft) 
		{
			projectile.type = ProjectileID.CrystalPulse;
			projectile.damage = 21;
			return true;
		}
	}
}