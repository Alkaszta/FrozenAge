using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Armors.GlacialArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class GlacialMask : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Inceased maximum mana by 15 and life by 10"
								+"\nSlightly increas mana regen");
		}
		
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(silver: 90);
            item.rare = 3;
			item.defense = 6;
        }
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GlacialBreastplate") && legs.type == mod.ItemType("GlacialGraves");
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus =  ("Slows enemy movement speed on hit"
								+"\nYour armor emits light"
								+"\nGive immune to chilled");
			player.buffImmune[BuffID.Chilled] = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.manaRegen = 2;
			player.statLifeMax2 += 10;
			player.statManaMax2 += 15;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GlacialBar"), 20);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}