namespace RobinMagic
{
  internal class Crafting
  {
    private readonly Dictionary<int, Item[]> Items = new();
    
    public Crafting()
    {
      // Wooden stick (Palo de madera).
      Items.Add(1, new Item[1] { new(5, "Wood", "W", 0, 0, new Point(0, 0), 41,
                      999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\wood.png") } );

      // Wooden ax.
      Items.Add(2, new Item[2]
        {
          new(11, "WoodenStick", "WS", 0, 0, new Point(0, 0), 2, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\woodenStick.png"),
          new(5, "Wood", "W", 0, 0, new Point(0, 0), 1, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\wood.png")
        }
      );

      // Wooden pickaxe.
      Items.Add(3, new Item[2]
        {
          new(11, "WoodenStick", "WS", 0, 0, new Point(0, 0), 2, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\woodenStick.png"),
          new(5, "Wood", "W", 0, 0, new Point(0, 0), 1, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\wood.png")
        }
      );

      // Wooden shovel.
      Items.Add(4, new Item[2]
        {
          new(11, "WoodenStick", "WS", 0, 0, new Point(0, 0), 2, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\woodenStick.png"),
          new(5, "Wood", "W", 0, 0, new Point(0, 0), 2, 999, "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\wood.png")
        }
      );
    }

    public Dictionary<int, Item[]> getItems() { return Items; }
  }
}
