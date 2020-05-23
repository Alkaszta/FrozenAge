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

namespace FrozenAge.Items.Weapons.Melee.IceSword
{
	public class IceSword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Basic sword from ice");  //The (English) text shown below your weapon's name*/
		}

		public override void SetDefaults() {
			item.damage = 15;           //The damage of your weapon
			item.melee = true;          //Is your weapon a melee weapon?
			item.width = 34;            //Weapon's texture's width
			item.height = 34;           //Weapon's texture's height
			item.useTime = 30;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 30;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 4;         //The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(silver: 30);           //The value of the weapon
			item.rare = 1;              //The rarity of the weapon, from -1 to 13
			item.UseSound = SoundID.Item1;      //The sound when the weapon is using
			item.autoReuse = false;          //Whether the weapon can use automatically by pressing mousebutton
			
				//Only need if this weapon shoot something
				//item.shoot = ProjectileID.IceSickle;	//Projectile type
				//item.shootSpeed = 50f;				//Projectile speed
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 20);
			recipe.AddIngredient(ItemID.IceBlock, 10);
			recipe.AddIngredient(ItemID.BorealWoodSword, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceSword"), 1);
			recipe.AddIngredient(ItemID.IceBlock, 5);
			recipe.AddIngredient(ItemID.Snowball, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.IceBlade);
			recipe.AddRecipe();
		}
		
		
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				//Emit dusts when swing the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Add Onfire buff to the NPC for 1 second
			// 60 frames = 1 second
			target.AddBuff(BuffID.Frostburn, 60);
		}


		//This is the recipe part, how to craft this weapon or from this other weapon(s)
		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("IceBrand"), 1);
			recipe.AddIngredient(ItemID.FrostCore, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/




		//This segments for extra particle(fancy, looks good)
		/*public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 132);
			}
		}*/



		//This segments for specific effects on enemys hurts
		/*public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) // <- Overriding.
		{
			//If the player on Specific biome(Snow)
			if(player.ZoneSnow)
			{
				target.AddBuff(BuffID.Frostburn, 300);
				if (player.ZoneDirtLayerHeight)
				{
					target.AddBuff(BuffID.Frostburn, 600);
				}
				if (player.ZoneRockLayerHeight)
				{
					target.AddBuff(BuffID.Frostburn, 900);
				}
			}
		}
		/* 
			//Without any circumstance
			target.AddBuff(BuffID.Frostburn, 120);
			player.statLife += 5;
		*/
		/*
			//If the player on Crimson and it is Night time
			if (player.ZoneCrimson == true || Main.dayTime == false)
			{
				target.AddBuff(BuffID.Ichor, 600);
			}
		*/
		


		//This for alternative usage of weapon(example:: left click: swing/right click: shoot)
		/*public override bool AltFunctionUse(Player player) {
			return true;
		}
		
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = 3;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 50;
				item.shoot = ProjectileID.IceSickle;
			}
			else {
				item.useStyle = 1;
				item.useTime = 40;
				item.useAnimation = 40;
				item.damage = 100;
				item.shoot = 0;
			}
			return base.CanUseItem(player);
		}*/



		//This segment is for shooting projectile
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//Shoot one direction, towards the cursor
			/*float numberProjectiles = 3; // 3 shots
            float rotation = MathHelper.ToRadians(45);//Shoots them in a 45 degree radius. (This is technically 90 degrees because it's 45 degrees up from your cursor and 45 degrees down)
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //45 should equal whatever number you had on the previous line
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Vector for spread. Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); //Creates a new projectile with our new vector for spread.
            }

			//Also shoots towards cursor but with different code
			/*for (int i = 0; i < 3; i++) //replace 3 with however many projectiles you like
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); //12 is the spread in degrees, although like with Set Spread it's technically a 24 degree spread due to the fact that it's randomly between 12 degrees above and 12 degrees below your cursor.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); //create the projectile
            }

			//Shoot from ceiling center towards cursor
			/*Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 2; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}*/


		//This segment for offset, if the weapon not in hand of the character
		/*public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}*/


		//Texture call
		/*
		public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.InfernoFriendlyBlast; } }
		*/
	}
}