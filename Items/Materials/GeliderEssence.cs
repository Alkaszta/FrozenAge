using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.Items.Materials
{
    public class GeliderEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's not cold, its extremely cold.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 20;
			item.rare = 8;
            item.maxStack = 999;
			item.value = Item.sellPrice(silver: 50);
			ItemID.Sets.ItemNoGravity[item.type] = true;
        }
		
		public override Color? GetAlpha(Color lightColor)
        {
			return Color.White;
		}
    }
}