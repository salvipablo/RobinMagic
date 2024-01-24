namespace RobinMagic
{
  internal class Player : Item
  {
    private static Player? _player;
    private static Item? itemInFront;

    public Player(int id, string name, char symbol, int itemToObtain, Point point) : base(id, name, symbol, itemToObtain, point)
    {
    }

    public static Player GetPlayer(int id, string name, char symbol, int itemToObtain, Point point)
    {
      _player ??= new Player(id, name, symbol, itemToObtain, point);
      return _player;
    }

    public static bool WasThereACollision(Point newPlayerPos)
    {
      itemInFront = GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item;
      return GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item.Symbol != ' ' || GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Tile.Material == "Ocean"; 
    }

    #pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
    public static Item GetItem() => itemInFront;

  }
}
