using RobinMagic.Items;

namespace RobinMagic
{
  internal class Item: IEquippableItems
  {
    public int Id {get; set;}
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public int ItemToObtain { get; set; }
    public int AmountToObtain { get; set; }
    public Point Location { get; set; }
    public int Amount { get; set; }
    public string? PathItem { get; set; }
    private float Life;

    public Item(int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem )
    {
      Id = id;
      Name = name;
      Symbol = symbol;
      ItemToObtain = itemToObtain;
      AmountToObtain = amountToObtain;
      Location = point;
      Life = life;
      Amount = amount;
      PathItem = pathItem;
    }

    public Item(int id, int amount)
    {
      Id = id;
      Amount = amount;
    }

    public float GetLife() { return Life; }

    public void LoseLife(float lifeToTake) { this.Life -= lifeToTake; }

    public virtual void ToEquip( Player player ) { throw new NotImplementedException(); }

    public  virtual void UnequipItem( Player player ) { throw new NotImplementedException(); }
  }
}