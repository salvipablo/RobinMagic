namespace RobinMagic
{
  internal class Tile
  {
    public int Id {  get; set; }
    public string Material { get; set; }
    public Color Color { get; set; }

    public Tile(int id, string material, Color color)
    {
      Id = id;
      Material = material;
      Color = color;
    }
  }
}
