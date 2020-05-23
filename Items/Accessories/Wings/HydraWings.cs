using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Accessories.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class HydraWings : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 38;
			item.value = Item.sellPrice(gold: 2); 
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 148;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
			if(player.ZoneSnow)
			{
				ascentWhenFalling = 1.5f;
				ascentWhenRising = 0.1f;
				maxCanAscendMultiplier = 2f;
				maxAscentMultiplier = 5f;
				constantAscend = 0.175f;
			}
			else
			{
				ascentWhenFalling = 0.9f;
				ascentWhenRising = 0.1f;
				maxCanAscendMultiplier = 1.2f;
				maxAscentMultiplier = 3f;
				constantAscend = 0.125f;
			}
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
			if(player.ZoneSnow)
			{
				speed = 10f;
				acceleration *= 2.75f;
			}
			else
			{
				speed = 8f;
				acceleration *= 2.5f;
			}
        }
    }
}