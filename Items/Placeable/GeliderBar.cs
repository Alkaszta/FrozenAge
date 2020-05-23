using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace FrozenAge.Items.Placeable
{
    public class GeliderBar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
			item.value = Item.sellPrice(gold: 1);
			item.rare = 7;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = mod.TileType("GeliderBarTile");
            item.maxStack = 99;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GeliderEssence"), 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}