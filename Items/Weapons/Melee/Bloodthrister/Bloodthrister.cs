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

namespace FrozenAge.Items.Weapons.Melee.Bloodthrister
{
	public class Bloodthrister : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Blood, so tasty for us. And yours is soo.. 'deep inhale'.. tempting.");
		}

		public override void SetDefaults() {
			item.damage = 96;
			item.melee = true;
			item.width = 56;
			item.height = 70;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = Item.buyPrice(gold: 8);
			item.rare = 8;
			item.UseSound = SoundID.Item39;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BloodDagger");
			item.shootSpeed = 18f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Frostburn, 720);
			player.statLife += 5;//Main.rand.Next(1,7);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) 
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 182);
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int) (damage * 1.15), knockBack, player.whoAmI);
			return false;
		}
	}
}