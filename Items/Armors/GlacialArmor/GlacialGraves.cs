using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Armors.GlacialArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class GlacialGraves : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Slightly increas mana regen"
								+"\n4% increased movement speed");
		}

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(silver: 70);
            item.rare = 3;
			item.defense = 7;
        }

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.04f;
			player.manaRegen = 1;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GlacialBar"), 25);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}