namespace RobinMagic
{
  internal class Player : Item
  {
    private static Player? _player;
    private static Item? itemInFront;
    private static bool IHaveKey = false;

    private Player(int id, string name, char symbol, int itemToObtain, Point point) : base(id, name, symbol, itemToObtain, point) { }

    public static Player GetPlayer(int id, string name, char symbol, int itemToObtain, Point point)
    {
      _player ??= new Player(id, name, symbol, itemToObtain, point);
      return _player;
    }

    public static bool WasThereACollision(Point newPlayerPos)
    {
      itemInFront = GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item;

      if (itemInFront.Name == "Key") return false;
      if (itemInFront.Name == "Door" && IHaveKey) return false;

      return GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item.Symbol != ' ' || GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Tile.Material == "Ocean"; 
    }

    public static void SetIHaveKey() { IHaveKey = true; }

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
    public static Item GetItem() => itemInFront;
  }
}
