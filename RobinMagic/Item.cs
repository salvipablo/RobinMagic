namespace RobinMagic
{
  internal class Item
  {
    public int Id {get; set;}
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int ItemToObtain { get; set; }
    public Point Location { get; set; }

    public Item(int id, string name, char symbol, int itemToObtain, Point point)
    {
      Id = id;
      Name = name;
      Symbol = symbol;
      ItemToObtain = itemToObtain;
      Location = point;
    }
  }
}
