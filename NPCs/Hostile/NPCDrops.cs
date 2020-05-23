using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FrozenAge.NPCs
{
	public class NPCDrops : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			
			if (npc.type == NPCID.SkeletronHead)
			{
				if(!FrozenAgeWorld.spawnOre)
				{
					Main.NewText("The world has generated a new ore", 200,200,55);
					for(int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 10E-05); i++)
                    {
                        WorldGen.TileRunner(
                            WorldGen.genRand.Next(0, Main.maxTilesX), // X Coord of the tile
                            WorldGen.genRand.Next((int)WorldGen.rockLayerLow, (int)WorldGen.rockLayerLow+200), // Y Coord of the tile
                            (double)WorldGen.genRand.Next(4, 8), // Strength (High = more)
                            WorldGen.genRand.Next(2, 4), // Steps 
                            mod.TileType("GlacialOreTile")); // The tile type that will be spawned
                    }
				}
				FrozenAgeWorld.spawnOre = true;
			}
		}
	}
}