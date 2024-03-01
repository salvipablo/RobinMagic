namespace RobinMagic
{
  internal class Player : Item
  {
    private static Player? _player;
    private static Item? itemInFront;
    private static bool IHaveKey = false;
    private float FellingSpeed = 0.5f;

    private Player(int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life) : 
                                                                    base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life) { }

    public static Player GetPlayer(int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life)
    {
      _player ??= new Player(id, name, symbol, itemToObtain, amountToObtain, point, amount, life);
      return _player;
    }

    public float GetFellingSpeed() { return FellingSpeed; }
    public void SetFellingSpeed(float fellingSpeed) { FellingSpeed += fellingSpeed; }

    public static bool WasThereACollision(Point newPlayerPos)
    {
      itemInFront = GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item;

      if (itemInFront.Name == "Key") return false;
      if (itemInFront.Name == "Wood") return false;
      if (itemInFront.Name == "Stone") return false;
      if (itemInFront.Name == "Iron") return false;
      if (itemInFront.Name == "Door" && IHaveKey) return false;

      return GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item.Symbol != ' ' || GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Tile.Material == "Ocean"; 
    }

    public static void SetIHaveKey() { IHaveKey = true; }

    #pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
    public static Item GetItem() => itemInFront;
  }
}
