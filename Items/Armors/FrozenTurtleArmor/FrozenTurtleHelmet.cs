using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Armors.FrozenTurtleArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class FrozenTurtleHelmet : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("6% increased melee damage" 
								+ "\nGives immune to Chilled and Frozen debuff");
		}
		
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(gold: 6);
            item.rare = 8;
			item.defense = 22;
        }
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("FrozenTurtleScaleMail") && legs.type == mod.ItemType("FrozenTurtleLeggnings");
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus =  "In snow storm gives you increased"
								+"\nmelee damage, speed, crit, and Blizzard aura."
								+"\nWhen health under 25% health grants you 32 armor.";
			player.noKnockback = true;
			if (player.ZoneSnow && player.ZoneRain)
			{
				player.meleeDamage += 0.02f;
				player.meleeSpeed += 0.02f;
				player.meleeCrit += 2;
			}
			if (player.statLife<100)
				player.statDefense += 32;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.meleeDamage += 0.06f;
		}

        public override void AddRecipes()
        {	
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrozenTurtleShell, 1);
            recipe.AddIngredient(mod.ItemType("GeliderBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}