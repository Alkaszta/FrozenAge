using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Armors.FrozenTurtleArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FrozenTurtleLeggings : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("4% increased melee crit"
								+ "\n5% increased melee speed"
								+ "\n6% increased movement speed"
								+ "\nGives immune to Chilled and Frozen debuff");
		}
		
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(gold: 3, silver:60);
            item.rare = 8;
			item.defense = 17;
        }
		
		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.meleeCrit += 4;
			player.meleeSpeed += 0.05f;
			player.moveSpeed += 0.06f;
		}

        public override void AddRecipes()
        {	
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrozenTurtleShell, 1);
            recipe.AddIngredient(mod.ItemType("GeliderBar"), 18);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}