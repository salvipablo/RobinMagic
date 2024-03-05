namespace RobinMagic.Items
{
  internal interface IEquippableItems
  {
    public void ToEquip(Player player);
    public void UnequipItem(Player player);
  }
}
