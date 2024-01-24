namespace RobinMagic
{
  internal static class GameMap
  {
    public static Sector[,] Sectors = new Sector[18, 18];
    public static Tile? tile;
    public static Item? item;

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
      Wood
    }

    public static void FillMap()
    {
      for (int y = 0; y < Sectors.GetLongLength(1); y++)
      {
        for (int x = 0; x < Sectors.GetLongLength(0); x++)
        {
          PlaceSector(x, y, Tiles.Land, Items.Empty, new Point(0, 0));

          // Land and Trees
          if (x == 3 && y == 11) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 5 && y == 12) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 6 && y == 14) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 9 && y == 10) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 10 && y == 11) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 13 && y == 1) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 15 && y == 2) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 15 && y == 4) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));
          if (x == 17 && y == 6) PlaceSector(x, y, Tiles.Land, Items.Tree, new Point(x, y));

          // Grass and Trees
          if (x == 14 && y == 8) PlaceSector(x, y, Tiles.Grass, Items.Tree, new Point(x, y));
          if (x == 15 && y == 11) PlaceSector(x, y, Tiles.Grass, Items.Tree, new Point(x, y));
          if (x == 17 && y == 8) PlaceSector(x, y, Tiles.Grass, Items.Tree, new Point(x, y));
          if (x == 17 && y == 12) PlaceSector(x, y, Tiles.Grass, Items.Tree, new Point(x, y));

          // Cement
          if (x == 1 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 10) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 11) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 12) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 1 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 2 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 4 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 7 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 9 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 10 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 11 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 12 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 13 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 14 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 15 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 16 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 17 && y == 13) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 2 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));

          // Ocean
          if (x == 0 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 1 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 2 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 3 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 4 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 5 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 6 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 7 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 8 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 9 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 10 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 11 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 12 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 13 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 14 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 15 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 16 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 17 && y == 16) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 0 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 1 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 2 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 3 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 4 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 5 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 6 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 7 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 8 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 9 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 10 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 11 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 12 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 13 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 14 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 15 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 16 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));
          if (x == 17 && y == 17) PlaceSector(x, y, Tiles.Ocean, Items.Empty, new Point(x, y));

          // Grass
          if (x == 13 && y == 7) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 13 && y == 8) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 13 && y == 9) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 13 && y == 10) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 13 && y == 11) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 13 && y == 12) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 14 && y == 7) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 14 && y == 9) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 14 && y == 10) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 14 && y == 11) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 14 && y == 12) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 15 && y == 7) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 15 && y == 8) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 15 && y == 9) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 15 && y == 10) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 15 && y == 12) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 16 && y == 7) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 16 && y == 8) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 16 && y == 9) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 16 && y == 10) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 16 && y == 11) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 16 && y == 12) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 17 && y == 7) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 17 && y == 9) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 17 && y == 10) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));
          if (x == 17 && y == 11) PlaceSector(x, y, Tiles.Grass, Items.Empty, new Point(x, y));

          // Castle
          if (x == 3 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 3 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 4 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 4 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 4 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 4 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 4 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Door, new Point(x, y));
          if (x == 4 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 4 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 4 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 4 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 5 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 5 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 5 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 6 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 6 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 6 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 7 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 7 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Cobble, new Point(x, y));
          if (x == 7 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 2) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 3) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 4) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 5) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 6) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 7) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 8) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));
          if (x == 8 && y == 9) PlaceSector(x, y, Tiles.Cement, Items.Empty, new Point(x, y));

          // Player
          if (x == 1 && y == 1) PlaceSector(x, y, Tiles.Cement, Items.Player, new Point(x, y));
        }
      }
    }

    public static Tile ReturnTile(int id)
    {
      if (id == 1) return new Tile(id, "Cement", Color.FromArgb(136, 129, 148));
      if (id == 2) return new Tile(id, "Ocean", Color.FromArgb(51, 59, 166));
      if (id == 3) return new Tile(id, "Grass", Color.FromArgb(54, 150, 38));
      return new Tile(id, "Land", Color.FromArgb(120, 67, 21));
    }

    public static Item ReturnItem(int id, Point point)
    {
      if ( id == 1 ) return new Item(id, "Player", '1', 0, new Point(point.X, point.Y));
      if ( id == 2 ) return new Item(id, "Cobble", 'C', 0, new Point(point.X, point.Y));
      if ( id == 3 ) return new Item(id, "Door", 'D', 0, new Point(point.X, point.Y));
      if ( id == 4 ) return new Item(id, "Tree", 'T', 4, new Point(point.X, point.Y));
      if ( id == 5 ) return new Item(id, "Wood", 'W', 0, new Point(point.X, point.Y));
      return new Item(id, "Empty", ' ', 0, new Point(point.X, point.Y));
    }

    public static void PlaceSector(int x, int y, Tiles tileToPlace, Items itemToPlace, Point pointItem)
    {
      int idTile = (int)tileToPlace;
      tile = ReturnTile(idTile);
      
      int idItem = (int)itemToPlace;
      item = ReturnItem(idItem, pointItem);

      Sector sector = new(tile, item);
      Sectors[x, y] = sector;
    }
  }
}