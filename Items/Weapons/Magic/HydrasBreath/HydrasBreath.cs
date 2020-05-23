using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Weapons.Magic.HydrasBreath
{
	public class HydrasBreath : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {
			item.damage = 132;
			item.magic = true;
			item.mana = 15;
			item.width = 68;
			item.height = 64;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3.25f;
			item.UseSound = SoundID.Item34;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FrozenBlueFlame");
			item.shootSpeed = 10f;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}
    }
}