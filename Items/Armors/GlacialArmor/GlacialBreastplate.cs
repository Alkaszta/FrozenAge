using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Armors.GlacialArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class GlacialBreastplate : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Inceased maximum mana by 5 and life by 20"
								+"\n3% increased magic damage");
		}

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(silver: 80);
            item.rare = 3;
			item.defense = 8;
        }

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.03f;
			player.statLifeMax2 += 20;
			player.statManaMax2 += 5;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GlacialBar"), 30);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}