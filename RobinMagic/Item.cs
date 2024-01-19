namespace RobinMagic
{
  internal class Item
  {
    private int Id;
    private string Name;
    private char Symbol;
    private int ItemToObtain;

    public Item(int id, string name, char symbol, int itemToObtain)
    {
      Id = id;
      Name = name;
      Symbol = symbol;
      ItemToObtain = itemToObtain;
    }
  }
}
