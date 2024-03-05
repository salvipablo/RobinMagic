namespace RobinMagic.Items
{
  internal class Pickaxe : Item, IEquippableItems
  {
    private float PickaxeSpeed = 3;
    public Pickaxe( int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life ) :
                                                                      base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life) { }

    public float getPickaxeSpeedSpeed() { return PickaxeSpeed; }

    public override void ToEquip(Player player)
    {
      player.SetPickaxeSpeed(PickaxeSpeed, true);
      player.EquipItem(new Pickaxe(12, "Pickaxe", 'P', 0, 0, new Point(0, 0), 1, 999));
    }

    public override void UnequipItem( Player player )
    {
      player.SetPickaxeSpeed(PickaxeSpeed, false);
      player.EquipItem(GameManager.ReturnItem(0, new Point(0, 0), 0));
    }
  }
}
