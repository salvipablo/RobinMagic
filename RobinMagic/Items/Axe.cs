namespace RobinMagic.Items
{
  internal class Axe : Item, IEquippableItems
  {
    private readonly float AxeSpeed = 2;

    public Axe( int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem ) : 
                                                                      base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem) { }
    
    public float GetAxeSpeed() { return AxeSpeed; }

    public override void ToEquip(Player player)
    {
      player.SetAxeSpeed(AxeSpeed, true);
      player.EquipItem(new Axe(11, "Axe", "A", 0, 0, new Point(0, 0), 1, 999, ""));
    }

    public override void UnequipItem(Player player)
    {
      player.SetAxeSpeed(AxeSpeed, false);
      player.EquipItem(GameManager.ReturnItem(0, new Point(0, 0), 0));
    }
  }
}
