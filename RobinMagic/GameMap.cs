using RobinMagic.Items;
using RobinMagicUI;

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
      Stone
    }

    public static void FillMap()
    {
      for (int y = 0; y < Sectors.GetLongLength(1); y++)
      {
        for (int x = 0; x < Sectors.GetLongLength(0); x++)
        {
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

          // Cement.
          if (x == 1 && y == 1) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 2) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 3) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 4) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 5) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 6) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 7) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 8) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 9) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 10) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 11) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 12) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 1 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 2 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 3 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 4 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 5 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 6 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 7 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 8 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 9 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 10 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 11 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 12 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 13 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 14 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 15 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 16 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 17 && y == 13) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));
          if (x == 2 && y == 5) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.Empty, new Point(x, y), 0));

          // RockFloor.
          if (x == 16 && y == 14) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 17 && y == 14) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 16 && y == 15) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 17 && y == 15) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));

          // Player.
          if (x == 16 && y == 16) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Land), GameManager.ReturnItem((int)Items.Player, new Point(x, y), 0));

          // RockFloor en otro lado del mapa.
          if (x == 25 && y == 3) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 26 && y == 3) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 25 && y == 4) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));
          if (x == 26 && y == 4) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Cement), GameManager.ReturnItem((int)Items.RockFloor, new Point(x, y), 0));

          // Grass and Trees en otro lado del mapa.
          if (x == 5 && y == 22) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 5 && y == 23) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 6 && y == 22) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
          if (x == 6 && y == 23) PlaceSector(x, y, GameManager.ReturnTile((int)Tiles.Grass), GameManager.ReturnItem((int)Items.Tree, new Point(x, y), 0));
        }
      }

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

      // Ocean.
      //if (x == 0 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));

      // Agrego un castilo
      Castle castle = new Castle(3, 1);
      for (int i = 0; i < castle.SectorsCastle.GetLongLength(1); i++)
      {
        for (int j = 0; j < castle.SectorsCastle.GetLongLength(0); j++)
        {
          PlaceSector(castle.LocationInXOnMap, castle.LocationInYOnMap, castle.SectorsCastle[j, i].Tile, castle.SectorsCastle[j, i].Item);
          castle.LocationInXOnMap++;
        }
        castle.LocationInXOnMap = 3;
        castle.LocationInYOnMap++;
      }
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
  }
}