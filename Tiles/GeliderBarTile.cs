using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;


namespace FrozenAge.Tiles
{
    public class GeliderBarTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.addTile(Type);
            
            drop = mod.ItemType("GeliderBar");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Metal Bar");
            AddMapEntry(new Color(224, 194, 101), name);
            minPick = 35;
        }
    }
}