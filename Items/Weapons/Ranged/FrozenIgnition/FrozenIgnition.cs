using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Weapons.Ranged.FrozenIgnition
{
	public class FrozenIgnition : ModItem
	{
        public override void SetDefaults()
        {
			item.damage = 83;
			item.ranged = true;
			item.width = 80;
			item.height = 27;
			item.useTime = 10;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3.25f;
			item.UseSound = SoundID.Item34;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 6;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FrozenFlame");
			item.shootSpeed = 40f;
			item.useAmmo = AmmoID.Gel;
		}
		
        public override bool ConsumeAmmo(Player player)
		{
            return Main.rand.NextFloat() > .50f;
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}