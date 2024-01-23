using System.Numerics;
using System.Windows.Forms;

namespace RobinMagic
{
  public partial class FrmMain : Form
  {
    private readonly int initialPositionScreenX = 10;
    private readonly int initialPositionScreenY = 10;
    private readonly int mapSectorSizeX = 30;
    private readonly int mapSectorSizeY = 30;
    private readonly Label[,] sectors = new Label[GameMap.Sectors.GetLongLength(0), GameMap.Sectors.GetLongLength(1)];

    public FrmMain()
    {
      InitializeComponent();
      init();
    }

    public void init()
    {
      Label label;
      int posX = initialPositionScreenX;
      int posY = initialPositionScreenY;

      for (int y = 0; y < GameMap.Sectors.GetLongLength(1); y++)
      {
        for (int x = 0; x < GameMap.Sectors.GetLongLength(0); x++)
        {
          label = new Label
          {
            AutoSize = false,
            BackColor = Color.FromArgb(0, 0, 0),
            Location = new Point(posX, posY),
            Name = $"label{x}{y}",
            Size = new Size(mapSectorSizeX, mapSectorSizeY),
            TabIndex = y,
            Text = "",
            TextAlign = ContentAlignment.MiddleCenter
          };
          sectors[x, y] = label;
          Controls.Add(sectors[x, y]);
          posX += mapSectorSizeX + 1;
        }
        posX = initialPositionScreenX;
        posY += mapSectorSizeY + 1;
      }

      GameMap.FillMap();
      ShowScreen();
    }

    public void ShowScreen()
    {
      for (int y = 0; y < GameMap.Sectors.GetLongLength(1); y++)
      {
        for (int x = 0; x < GameMap.Sectors.GetLongLength(0); x++)
        {
          sectors[x, y].Text = GameMap.Sectors[x, y].Item.Symbol.ToString();
          sectors[x, y].BackColor = GameMap.Sectors[x, y].Tile.Color;
        }
      }
    }
  }
}
