using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace FrozenAge.Items.Placeable
{
    public class GlacialOre : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.useTime = 10;
            item.useAnimation = 15;
            item.useStyle = 1;
			item.useTurn = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = 4;
            item.autoReuse = true;
            item.consumable = true; 
            item.createTile = mod.TileType("GlacialOreTile");
            item.maxStack = 999;
        }
    }
}