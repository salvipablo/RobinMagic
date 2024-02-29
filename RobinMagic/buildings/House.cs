using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinMagic.buildings
{
  internal class House
  {
    public Sector[,] SectorHouse = new Sector[3, 3];
    public int LocationInXOnMap;
    public int LocationInYOnMap;

    public House( int locationInXOnMap, int locationInYOnMap )
    {
      LocationInXOnMap = locationInXOnMap;
      LocationInYOnMap = locationInYOnMap;
      BuildHouse();
    }

    public void BuildHouse()
    {
      int x = -1;
      int y = -1;
      string? line;

      try
      {
        StreamReader sr = new("C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\buildings\\House_3x3\\Tiles.txt");
        line = sr.ReadLine();
        while (line != null)
        {
          y++;

          foreach (char letter in line)
          {
            x++;
            int idTile = ReturnIDTileFromChar(letter);
            SectorHouse[x, y] = new Sector(GameManager.ReturnTile(idTile), GameManager.ReturnItem(0, new Point(0, 0), 0));
          }

          x = -1;

          line = sr.ReadLine();
        }

        sr.Close();
      }
      catch (Exception e) { MessageBox.Show($"Exception: {e.Message}"); }

      int posItemX = 13;
      int posItemY = 21;

      x = -1;
      y = -1;
      try
      {
        StreamReader sr = new("C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\buildings\\House_3x3\\Items.txt");
        line = sr.ReadLine();
        while (line != null)
        {
          y++;

          foreach (char letter in line)
          {
            x++;
            int idItem = ReturnIDItemFromChar(letter);
            SectorHouse[x, y].Item = GameManager.ReturnItem(idItem, new Point(posItemX, posItemY), 0);
            posItemX++;
          }

          x = -1;
          posItemY++;

          line = sr.ReadLine();
        }

        sr.Close();
      }
      catch (Exception e) { MessageBox.Show($"Exception: {e.Message}"); }
    }

    private int ReturnIDTileFromChar( char character )
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
