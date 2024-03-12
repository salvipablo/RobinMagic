namespace RobinMagic.Items
{
  internal class Pickaxe : Item, IEquippableItems
  {
    private readonly float PickaxeSpeed = 3;

    public Pickaxe( int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem ) :
                                                                      base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem) { }

    public float GetPickaxeSpeedSpeed() { return PickaxeSpeed; }

    public override void ToEquip(Player player)
    {
      player.SetPickaxeSpeed(PickaxeSpeed, true);
      player.EquipItem(new Pickaxe(12, "Pickaxe", "P", 0, 0, new Point(0, 0), 1, 999, ""));
    }

    public override void UnequipItem( Player player )
    {
      player.SetPickaxeSpeed(PickaxeSpeed, false);
      player.EquipItem(GameManager.ReturnItem(0, new Point(0, 0), 0));
    }
  }
}
