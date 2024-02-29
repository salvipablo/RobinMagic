using System.Drawing;

namespace RobinMagic
{
  internal static class GameManager
  {
    public static Tile ReturnTile(int id)
    {
      if (id == 1) return new Tile(id, "Cement", Color.FromArgb(136, 129, 148));
      if (id == 2) return new Tile(id, "Ocean", Color.FromArgb(51, 59, 166));
      if (id == 3) return new Tile(id, "Grass", Color.FromArgb(54, 150, 38));
      if (id == 4) return new Tile(id, "Sand", Color.FromArgb(219, 219, 166));
      return new Tile(id, "Land", Color.FromArgb(120, 67, 21));
    }

    public static Item ReturnItem(int id, Point point, int amount )
    {
      Item itemToReturn = new(id, "Empty", ' ', 0, 0, new Point(point.X, point.Y), 0, amount);

      if (id == 1) itemToReturn = new(id, "Player", '1', 0, 0, new Point(point.X, point.Y), amount, 100);
      if (id == 2) itemToReturn = new(id, "Cobble", 'C', 0, 0, new Point(point.X, point.Y), amount, 999);
      if (id == 3) itemToReturn = new(id, "Door", 'D', 0, 0, new Point(point.X, point.Y), amount, 999);
      if (id == 4) itemToReturn = new(id, "Tree", 'T', 5, 10, new Point(point.X, point.Y), amount, 6);
      if (id == 5) itemToReturn = new(id, "Wood", 'W', 0, 0, new Point(point.X, point.Y), amount, 999);
      if (id == 6) itemToReturn = new(id, "Key", 'K', 0, 0, new Point(point.X, point.Y), amount, 999);
      if (id == 7) itemToReturn = new(id, "RockFloor", 'R', 8, 5, new Point(point.X, point.Y), amount, 15);
      if (id == 8) itemToReturn = new(id, "Stone", 'S', 0, 0, new Point(point.X, point.Y), amount, 999);
      if (id == 9) itemToReturn = new(id, "IronOre", 'i', 10, 2, new Point(point.X, point.Y), amount, 20);
      if (id == 10) itemToReturn = new(id, "Iron", 'I', 0, 0, new Point(point.X, point.Y), amount, 999);

      return itemToReturn;
    }
  }
}
