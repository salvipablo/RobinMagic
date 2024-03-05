namespace RobinMagic
{
  internal class Item
  {
    public int Id {get; set;}
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int ItemToObtain { get; set; }
    public int AmountToObtain { get; set; }
    public Point Location { get; set; }
    public int Amount { get; set; }
    private float Life;

    public Item(int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life)
    {
      Id = id;
      Name = name;
      Symbol = symbol;
      ItemToObtain = itemToObtain;
      AmountToObtain = amountToObtain;
      Location = point;
      Life = life;
      Amount = amount;
    }

    public float GetLife() { return Life; }

    public void LoseLife(float lifeToTake) { this.Life -= lifeToTake; }

    public virtual void ToEquip(Player player) { }
    public virtual void UnequipItem(Player player) { }
  }
}