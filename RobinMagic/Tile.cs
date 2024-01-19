namespace RobinMagic
{
  internal class Tile
  {
    private int Id;
    private string Material;
    private Color Color;

    public Tile(int id, string material, Color color)
    {
      Id = id;
      Material = material;
      Color = color;
    }
  }
}
