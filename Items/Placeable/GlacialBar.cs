using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace FrozenAge.Items.Placeable
{
    public class GlacialBar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
			item.value = Item.sellPrice(silver: 20);
			item.rare = 4;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("GlacialBarTile");
            item.maxStack = 99;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GlacialOre"), 4);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}