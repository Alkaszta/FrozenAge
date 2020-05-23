using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Armors.FrozenTurtleArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class FrozenTurtleScaleMail : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("5% inceased melee crit"
								+ "\n6% inceased melee damage"
								+ "\nGives immune to Chilled and Frozen debuff");
		}
		
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(gold: 4, silver: 80);
            item.rare = 8;
			item.defense = 29;
        }
		
		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.meleeDamage += 0.06f;
			player.meleeCrit += 5;
		}

        public override void AddRecipes()
        {	
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrozenTurtleShell, 1);
            recipe.AddIngredient(mod.ItemType("GeliderBar"), 24);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}