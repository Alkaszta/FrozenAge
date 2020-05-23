using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Weapons.Magic.SnowFallRod
{
	class SnowFallRod : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 100;
			item.width = 35;
			item.height = 34;
			item.maxStack = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.buyPrice(gold: 35);
			item.rare = 7;
			item.UseSound = SoundID.Item66;
			item.noMelee = true;
			item.mana = 10;
			item.magic = true;
			item.shoot = mod.ProjectileType("SnowCloudFly");
			//item.shootSpeed = 20f;
		}
	}

	class SnowCloudFly : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.timeLeft = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 0;
		}
		
		public override void AI()
        {
			projectile.damage = 0;
            projectile.light = 0.9f;
        }
		
		public override bool PreKill(int timeLeft)
        {
			Vector2 mousePosition = Main.MouseWorld;
			
            Projectile.NewProjectile(mousePosition.X, mousePosition.Y, 0, 0, ModContent.ProjectileType<SnowCloud>(), 0, projectile.knockBack);
			return false;
        }
	}
	
	class SnowCloud : ModProjectile
    {
		public override void SetDefaults()
		{
			projectile.width = 54;
			projectile.height = 24;
			projectile.timeLeft = 6000;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.aiStyle = 0;
		}
		
		public override void AI()
        {
			projectile.damage = 0;
            projectile.light = 0.9f;
			
            int DustID1 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 76, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
            Main.dust[DustID1].noGravity = true;
			
			Projectile.NewProjectile((projectile.Center.X+Main.rand.Next(-20,20))*Main.rand.Next(5), projectile.Center.Y + 10, 0, Main.rand.Next(1,3), ModContent.ProjectileType<Snow>(), 0, projectile.knockBack);
		}
    }
	
	class Snow : ModProjectile
    {
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.timeLeft = 1000;
			projectile.extraUpdates = 1;
		}
		
        public override void AI()
        {
			projectile.friendly = true;
			projectile.damage = 100;
			projectile.aiStyle = 45;
			projectile.penetrate = -1;
			projectile.magic = true;
			
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 1f), projectile.width, projectile.height, 76, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 120, default(Color), 0.5f);
            Main.dust[DustID].noGravity = true;
        }
    }
}