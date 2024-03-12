namespace RobinMagic.Items
{
  internal class Shovel : Item, IEquippableItems
  {
    private readonly float ShovelSpeed = 1.5f;

    public Shovel( int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem ) :
                                                              base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem) { }

    public override void ToEquip(Player player)
    {
      player.SetShovelSpeed(ShovelSpeed, true);
      player.EquipItem(new Shovel(13, "Shovel", "S", 0, 0, new Point(0, 0), 1, 999, ""));
    }

    public override void UnequipItem( Player player )
    {
      player.SetShovelSpeed(ShovelSpeed, false);
      player.EquipItem(GameManager.ReturnItem(0, new Point(0, 0), 0));
    }
  }
}
