using RobinMagic;

namespace RobinMagicUI
{
  internal class Castle
  {
    public Sector[,] SectorsCastle = new Sector[6, 9];
    public int LocationInXOnMap;
    public int LocationInYOnMap;

    public Castle(int locationInXOnMap , int locationInYOnMap )
    {
      LocationInXOnMap = locationInXOnMap;
      LocationInYOnMap = locationInYOnMap;
      BuildCastle();
    }

    public void BuildCastle()
    {
      int x = -1;
      int y = -1;
      string? line;

      try
      {
        StreamReader sr = new("C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\buildings\\Castle_6x9\\Tiles.txt");
        line = sr.ReadLine();
        while (line != null)
        {
          y++;

          foreach (char letter in line)
          {
            x++;
            int idTile = ReturnIDTileFromChar(letter);
            SectorsCastle[x, y] = new Sector(GameManager.ReturnTile(idTile), GameManager.ReturnItem(0, new Point(0, 0), 0));
          }

          x = -1;

          line = sr.ReadLine();
        }

        sr.Close();
      }
      catch (Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
      }

      int posItemX = 3;
      int posItemY = 1;

      x = -1;
      y = -1;
      try
      {
        StreamReader sr = new("C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\buildings\\Castle_6x9\\Items.txt");
        line = sr.ReadLine();
        while (line != null)
        {
          y++;

          foreach (char letter in line)
          {
            x++;
            int idItem = ReturnIDItemFromChar(letter);
            SectorsCastle[x, y].Item = GameManager.ReturnItem(idItem, new Point(posItemX, posItemY), 0);
            posItemX++;
          }

          x = -1;
          posItemY++;

          line = sr.ReadLine();
        }

        sr.Close();
      }
      catch (Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
      }
    }

    private int ReturnIDTileFromChar(char character)
    {
      if (character == 'C') return 1;
      return 0;
    }

    private int ReturnIDItemFromChar( char character )
    {
      if (character == 'C') return 2;
      if (character == 'D') return 3;
      return 0;
    }
  }
}
