namespace RobinMagic
{
  internal class Item
  {
    public int Id {get; set;}
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int ItemToObtain { get; set; }
    public Point Location { get; set; }
    private float Life;

    public Item(int id, string name, char symbol, int itemToObtain, Point point, float life)
    {
      Id = id;
      Name = name;
      Symbol = symbol;
      ItemToObtain = itemToObtain;
      Location = point;
      Life = life;
    }

    public float GetLife() { return Life; }

    public void LoseLife( float lifeToTake )
    {
      this.Life -= lifeToTake;
    }
  }
}
