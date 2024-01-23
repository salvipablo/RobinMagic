using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinMagic
{
  internal static class GameMap
  {
    public static Sector[,] Sectors = new Sector[18, 18];
    public static Tile tile;
    public static Item item;

    public static void FillMap()
    {
      

      for (int y = 0; y < Sectors.GetLongLength(1); y++)
      {
        for (int x = 0; x < Sectors.GetLongLength(0); x++)
        {
          PlaceLand(x, y, 1, new Point(0, 0));

          if (x == 3 && y == 11) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 5 && y == 12) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 6 && y == 14) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 9 && y == 10) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 10 && y == 11) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 13 && y == 1) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 15 && y == 2) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 15 && y == 4) PlaceLand(x, y, 4, new Point(x, y));
          if (x == 17 && y == 6) PlaceLand(x, y, 4, new Point(x, y));

          if (x == 1 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 2) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 3) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 4) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 5) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 6) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 7) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 8) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 10) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 11) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 12) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 2 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 4 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 5 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 6 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 7 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 9 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 10 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 11 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 12 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 13) PlaceCement(x, y, 1, new Point(0, 0)  );
          if (x == 16 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 13) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 2 && y == 5) PlaceCement(x, y, 1, new Point(0, 0));

          if (x == 0 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 2 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 4 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 5 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 6 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 7 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 9 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 10 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 11 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 12 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 16) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 0 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 1 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 2 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 4 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 5 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 6 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 7 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 9 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 10 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 11 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 12 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 17) PlaceOcean(x, y, 1, new Point(0, 0));

          if (x == 13 && y == 7) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 8) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 9) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 10) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 11) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 13 && y == 12) PlaceGrass(x, y , 1, new Point(0, 0));
          if (x == 14 && y == 7) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 8) PlaceGrass(x, y, 4, new Point(x, y));
          if (x == 14 && y == 9) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 10) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 11) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 14 && y == 12) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 7) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 8) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 9) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 10) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 15 && y == 11) PlaceGrass(x, y, 4, new Point(x, y));
          if (x == 15 && y == 12) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 7) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 8) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 9) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 10) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 11) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 16 && y == 12) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 7) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 8) PlaceGrass(x, y, 4, new Point(x, y));
          if (x == 17 && y == 9) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 10) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 11) PlaceGrass(x, y, 1, new Point(0, 0));
          if (x == 17 && y == 12) PlaceGrass(x, y, 4, new Point(x, y));

          // Castle
          if (x == 3 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 2) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 3) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 4) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 5) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 6) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 7) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 8) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 3 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));

          if (x == 4 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 4 && y == 2) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 4 && y == 3) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 4 && y == 4) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 4 && y == 5) PlaceCement(x, y, 3, new Point(x, y));
          if (x == 4 && y == 6) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 4 && y == 7) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 4 && y == 8) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 4 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));

          if (x == 5 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 5 && y == 2) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 5 && y == 3) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 5 && y == 4) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 5 && y == 5) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 5 && y == 6) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 5 && y == 7) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 5 && y == 8) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 5 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));

          if (x == 6 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 6 && y == 2) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 6 && y == 3) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 6 && y == 4) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 6 && y == 5) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 6 && y == 6) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 6 && y == 7) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 6 && y == 8) PlaceCement(x, y, 1, new Point(x, y));
          if (x == 6 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));

          if (x == 7 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 7 && y == 2) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 3) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 4) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 5) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 6) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 7) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 8) PlaceCement(x, y, 2, new Point(x, y));
          if (x == 7 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));

          if (x == 8 && y == 1) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 2) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 3) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 4) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 5) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 6) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 7) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 8) PlaceCement(x, y, 1, new Point(0, 0));
          if (x == 8 && y == 9) PlaceCement(x, y, 1, new Point(0, 0));
        }
      }
    }

    public static Item ReturnItem(int id, Point point)
    {
      if ( id == 2 ) return new Item(id, "Cobble", 'C', 0, new Point(point.X, point.Y));
      if ( id == 3 ) return new Item(id, "Door", 'D', 0, new Point(point.X, point.Y));
      if ( id == 4 ) return new Item(id, "Tree", 'T', 4, new Point(point.X, point.Y));
      if ( id == 5 ) return new Item(id, "Wood", 'W', 0, new Point(point.X, point.Y));
      return new Item(id, "Empty", ' ', 0, new Point(point.X, point.Y));
    }

    public static void PlaceCement(int x, int y, int idItem, Point pointItem)
    {
      tile = new Tile(2, "Cement", Color.FromArgb(136, 129, 148));
      item = ReturnItem(idItem, pointItem);
      Sector sector = new Sector(tile, item);
      Sectors[x, y] = sector;
    }

    public static void PlaceLand(int x, int y, int idItem, Point pointItem)
    {
      tile = new Tile(1, "Land", Color.FromArgb(120, 67, 21));
      item = ReturnItem(idItem, pointItem);
      Sector sector = new Sector(tile, item);
      Sectors[x, y] = sector;
    }

    public static void PlaceOcean(int x, int y, int idItem, Point pointItem)
    {
      tile = new Tile(3, "Ocean", Color.FromArgb(51, 59, 166));
      item = ReturnItem(idItem, pointItem);
      Sector sector = new Sector(tile, item);
      Sectors[x, y] = sector;
    }

    public static void PlaceGrass(int x, int y, int idItem, Point pointItem)
    {
      tile = new Tile(4, "Grass", Color.FromArgb(54, 150, 38));
      item = ReturnItem(idItem, pointItem);
      Sector sector = new Sector(tile, item);
      Sectors[x, y] = sector;
    }
  }
}