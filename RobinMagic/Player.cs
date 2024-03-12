namespace RobinMagic
{
  internal class Player : Item
  {
    private static Player? _player;
    private static Item? itemInFront;
    private static bool IHaveKey = false;

    private readonly float AxeSpeedStat = 0.5f;  // Hacha Default.
    private readonly float PickaxeSpeedStat = 0.5f;  // Pico Default.
    private readonly float ShovelSpeedStat = 0.5f;  // Pico Default.

    private float AxeSpeed = 0.5f;  // Hacha.
    private float PickaxeSpeed = 0.5f;  // Pico.
    private float ShovelSpeed = 0.5f;  // Pico Default.

    private readonly List<Item> Items = new();  // Items equipados.

    private Item EquippedItem = GameManager.ReturnItem(0, new Point(0, 0), 0);

    private Player(int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem ) : 
                                                                    base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem) { }

    public static Player GetPlayer(int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem )
    {
      _player ??= new Player(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem);
      return _player;
    }

    public void EquipItem(Item item) { EquippedItem = item; }

    public Item ItemEquippedOnPlayer() { return EquippedItem; }

    public void AddItem(Item item) { Items.Add(item); }

    public List<Item> GetItems() { return Items; }

    public float GetPickaxeSpeed() { return PickaxeSpeed; }

    public void SetPickaxeSpeed(float pickaxeSpeed, bool Equip)
    {
      if (Equip) PickaxeSpeed = PickaxeSpeedStat + pickaxeSpeed;
      else PickaxeSpeed = PickaxeSpeedStat;
    }

    public float GetAxeSpeed() { return AxeSpeed; }

    public void SetAxeSpeed(float fellingSpeed, bool Equip)
    {
      if ( Equip ) AxeSpeed = AxeSpeedStat + fellingSpeed;
      else AxeSpeed = AxeSpeedStat;
    }

    public float GetShovelSpeed() { return ShovelSpeed; }

    public void SetShovelSpeed( float shovelSpeed, bool Equip )
    {
      if (Equip) ShovelSpeed = ShovelSpeedStat + shovelSpeed;
      else ShovelSpeed = ShovelSpeedStat;
    }

    public static bool WasThereACollision(Point newPlayerPos)
    {
      itemInFront = GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item;

      if (itemInFront.Name == "Key") return false;
      if (itemInFront.Name == "Wood") return false;
      if (itemInFront.Name == "Stone") return false;
      if (itemInFront.Name == "Iron") return false;
      if (itemInFront.Name == "Axe") return false;
      if (itemInFront.Name == "Pickaxe") return false;
      if (itemInFront.Name == "Shovel") return false;
      if (itemInFront.Name == "Door" && IHaveKey) return false;

      return GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item.Symbol != " " || GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Tile.Material == "Ocean"; 
    }

    public static void SetIHaveKey() { IHaveKey = true; }

    #pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
    public static Item GetItem() => itemInFront;
  }
}
