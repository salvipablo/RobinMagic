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
      Item itemToReturn = new(id, "Empty", " ", 0, 0, new Point(point.X, point.Y),
                          0, amount, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\empty.png");

      if (id == 1) itemToReturn = new(id, "Player", "P1" , 0, 0, new Point(point.X, point.Y), amount, 100, "");
      if (id == 2) itemToReturn = new(id, "Cobble", "C", 0, 0, new Point(point.X, point.Y), amount, 999, "");
      if (id == 3) itemToReturn = new(id, "Door", "D", 0, 0, new Point(point.X, point.Y),
                        amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\door.png");
      if (id == 4) itemToReturn = new(id, "Tree", "T", 5, 10, new Point(point.X, point.Y),
                          amount, 6, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\tree.png");
      if (id == 5) itemToReturn = new(id, "Wood", "W", 0, 0, new Point(point.X, point.Y),
                        amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\wood.png");
      if (id == 6) itemToReturn = new(id, "Key", "K", 0, 0, new Point(point.X, point.Y),
                        amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\wood.png");
      if (id == 7) itemToReturn = new(id, "RockFloor", "RF", 8, 5, new Point(point.X, point.Y),
                    amount, 15, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\rockFloor.png");
      if (id == 8) itemToReturn = new(id, "Stone", "S", 0, 0, new Point(point.X, point.Y),
                       amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\stone.png");
      if (id == 9) itemToReturn = new(id, "IronOre", "IO", 10, 2, new Point(point.X, point.Y),
                      amount, 20, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\IronOre.png");
      if (id == 10) itemToReturn = new(id, "Iron", "I", 0, 0, new Point(point.X, point.Y),
                        amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\Iron.png");
      if (id == 11) itemToReturn = new(id, "WoodenStick", "WS", 0, 0, new Point(point.X, point.Y),
                 amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\woodenStick.png");
      if (id == 12) itemToReturn = new(id, "Axe", "AX", 0, 0, new Point(point.X, point.Y),
                 amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\axe.png");
      if (id == 13) itemToReturn = new(id, "Pickaxe", "PA", 0, 0, new Point(point.X, point.Y),
                 amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\pickaxe.png");
      if (id == 14) itemToReturn = new(id, "Shovel", "SH", 0, 0, new Point(point.X, point.Y),
                 amount, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\shovel.png");

      return itemToReturn;
    }
  }
}