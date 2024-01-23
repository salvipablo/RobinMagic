namespace RobinMagic
{
  internal class Sector
  {
    public Tile Tile { get; set; }
    public Item Item { get; set; }

    public Sector(Tile tile, Item item)
    {
      Tile = tile;
      Item = item;
    }
  }
}
