using RobinMagic.buildings;
using RobinMagic.Items;
using RobinMagicUI;
using System.Drawing;

namespace RobinMagic
{
  internal static class GameMap
  {
    public static Sector[,] Sectors = new Sector[36, 36];

    public enum Tiles
    {
      Land,
      Cement,
      Ocean,
      Grass,
      Sand
    }

    public enum Items
    {
      Empty,
      Player,
      Cobble,
      Door,
      Tree,
      Wood,
      Key,
      RockFloor,
      Stone,
      IronOre
    }

    public static void FillMap(int playerPlacementPositionX, int playerPlacementPositionY)
    {
      for (int y = 0; y < Sectors.GetLongLength(1); y++)
      {
        for (int x = 0; x < Sectors.GetLongLength(0); x++)
        {
          // By default, common ground is placed and item is placed empty.
          PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));

          // Land and Trees.
          if (x == 3 && y == 11) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 5 && y == 12) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 6 && y == 14) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 9 && y == 10) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 10 && y == 11) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 13 && y == 1) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 15 && y == 2) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 15 && y == 4) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 17 && y == 6) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));

          // RockFloor.
          if (x == 16 && y == 14) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 17 && y == 14) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 16 && y == 15) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 17 && y == 15) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 25 && y == 3) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 26 && y == 3) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 25 && y == 4) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 26 && y == 4) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));

          // Iron ore.
          if (x == 0 && y == 27) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 0 && y == 28) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 0 && y == 29) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 1 && y == 27) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 1 && y == 28) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 1 && y == 29) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 2 && y == 27) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 2 && y == 28) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
          if (x == 2 && y == 29) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.IronOre, new Point(x, y), 0));
        }
      }

      // Cement.
      GameMap.PlaceCement();

      // Ocean.
      GameMap.PlaceOcean();

      // Sand.
      GameMap.PlaceSand();

      // Player.
      PlaceSector(playerPlacementPositionX, playerPlacementPositionY, GameManager.ReturnTile((int)Tiles.Land),
                          GameManager.ReturnItem((int)Items.Player, new Point(playerPlacementPositionX, playerPlacementPositionY), 0));

      // Grass and Trees.
      for (int y = 7; y < 12; y++)
      {
        for (int x = 13; x < 18; x++)
        {
          PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 14 && y == 8) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 15 && y == 11) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 17 && y == 8) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 17 && y == 11) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
        }
      }

      // Grass.
      PlaceGrass();

      // Castle
      PlaceCastle(new Castle(3, 1));

      // Houses.
      PlaceHouse(new House(13, 21));
      PlaceHouse(new House(25, 21));
      PlaceHouse(new House(32, 27));
      PlaceHouse(new House(28, 11));
    }

    public static void PlaceKey(Key key)
    {
      PlaceSector(key.Location.X, key.Location.Y, GameManager.ReturnTile((int)Tiles.Grass), 
                                                GameManager.ReturnItem((int)Items.Key, new Point(key.Location.X, key.Location.Y), 0));
    }

    public static void PlaceSector( int x, int y, Tile tile, Item item)
    {
      Sector sector = new(tile, item);
      Sectors[x, y] = sector;
    }

    private static void PlaceCement()
    {
      PlaceSector(1, 1, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 1), 0));
      PlaceSector(1, 2, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 2), 0));
      PlaceSector(1, 3, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 3), 0));
      PlaceSector(1, 4, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 4), 0));
      PlaceSector(1, 5, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 5), 0));
      PlaceSector(1, 6, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 6), 0));
      PlaceSector(1, 7, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 7), 0));
      PlaceSector(1, 8, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 8), 0));
      PlaceSector(1, 9, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 9), 0));
      PlaceSector(1, 10, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 10), 0));
      PlaceSector(1, 11, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 11), 0));
      PlaceSector(1, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 12), 0));
      PlaceSector(1, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(1, 13), 0));
      PlaceSector(2, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(2, 13), 0));
      PlaceSector(3, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(3, 13), 0));
      PlaceSector(4, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(4, 13), 0));
      PlaceSector(5, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(5, 13), 0));
      PlaceSector(6, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(6, 13), 0));
      PlaceSector(7, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(7, 13), 0));
      PlaceSector(8, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(8, 13), 0));
      PlaceSector(9, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(9, 13), 0));
      PlaceSector(10, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(10, 13), 0));
      PlaceSector(11, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(11, 13), 0));
      PlaceSector(12, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(12, 13), 0));
      PlaceSector(13, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(13, 13), 0));
      PlaceSector(14, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(14, 13), 0));
      PlaceSector(15, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(15, 13), 0));
      PlaceSector(16, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(16, 13), 0));
      PlaceSector(17, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(18, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(19, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(20, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(21, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 13, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 14, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 15, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 16, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 17, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 18, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 19, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 20, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 21, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 22, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 23, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 24, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 25, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 26, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 27, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 29, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(22, 30, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
      PlaceSector(10, 14, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 15, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 16, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 17, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 18, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 19, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 20, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 21, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 22, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 23, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 24, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 25, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 26, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 27, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 29, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(10, 30, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(0, 0), 0));
      PlaceSector(2, 5, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(2, 5), 0));

      PlaceSector(23, 22, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(23, 22), 0));
      PlaceSector(24, 22, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(24, 22), 0));

      PlaceSector(23, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(23, 28), 0));
      PlaceSector(24, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(24, 28), 0));
      PlaceSector(25, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(25, 28), 0));
      PlaceSector(26, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(26, 28), 0));
      PlaceSector(27, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(27, 28), 0));
      PlaceSector(28, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(28, 28), 0));
      PlaceSector(29, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(29, 28), 0));
      PlaceSector(30, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(30, 28), 0));
      PlaceSector(31, 28, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(31, 28), 0));

      PlaceSector(22, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(22, 12), 0));
      PlaceSector(23, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(23, 12), 0));
      PlaceSector(24, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(24, 12), 0));
      PlaceSector(25, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(25, 12), 0));
      PlaceSector(26, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(26, 12), 0));
      PlaceSector(27, 12, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(27, 12), 0));

      PlaceSector(11, 22, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(11, 22), 0));
      PlaceSector(12, 22, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(12, 22), 0));
    }

    private static void PlaceGrass()
    {
      for (int y = 0; y < 31; y++)
      {
        for (int x = 33; x < 36; x++)
        {
          PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
        }
      }
    }

    private static void PlaceOcean()
    {
      for (int y = 33; y < 36; y++)
      {
        for (int x = 0; x < 36; x++)
        {
          PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Ocean), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
        }
      }
    }

    private static void PlaceSand()
    {
      for (int y = 31; y < 33; y++)
      {
        for (int x = 0; x < 36; x++)
        {
          PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Sand), GameManager.ReturnItem((int)Items.Empty, new Point(17, 13), 0));
        }
      }
    }

    private static void PlaceHouse(House house)
    {
      int StartingPointBuildingX = house.LocationInXOnMap;

      for (int i = 0; i < house.SectorHouse.GetLongLength(1); i++)
      {
        for (int j = 0; j < house.SectorHouse.GetLongLength(0); j++)
        {
          PlaceSector(house.LocationInXOnMap, house.LocationInYOnMap, house.SectorHouse[j, i].Tile, house.SectorHouse[j, i].Item);
          house.LocationInXOnMap++;
        }
        house.LocationInXOnMap = StartingPointBuildingX;
        house.LocationInYOnMap++;
      }
    }

    private static void PlaceCastle(Castle castle)
    {
      int StartingPointBuildingX = castle.LocationInXOnMap;
      for (int i = 0; i < castle.SectorsCastle.GetLongLength(1); i++)
      {
        for (int j = 0; j < castle.SectorsCastle.GetLongLength(0); j++)
        {
          PlaceSector(castle.LocationInXOnMap, castle.LocationInYOnMap, castle.SectorsCastle[j, i].Tile, castle.SectorsCastle[j, i].Item);
          castle.LocationInXOnMap++;
        }
        castle.LocationInXOnMap = StartingPointBuildingX;
        castle.LocationInYOnMap++;
      }
    }
  }
}