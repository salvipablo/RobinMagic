using System.Drawing;
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
    private readonly Item? player = Player.GetPlayer(1, "Pablo", '1', 0, new Point(1, 1));

    public FrmMain()
    {
      InitializeComponent();
      Init();
    }

    public void Init()
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
          sectors[x, y].BackColor = GameMap.Sectors[x, y].Tile.Color;
          sectors[x, y].Text = GameMap.Sectors[x, y].Item.Symbol.ToString();
        }
      }
    }

    private void FrmMain_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) this.PlayerMove(e);
    }

    private void PlayerMove(KeyEventArgs keyPressed)
    {
      Point playerPosAfterMov = player!.Location;

      if (keyPressed.KeyCode == Keys.Down && player.Location.Y < 17) playerPosAfterMov.Y += 1;
      if (keyPressed.KeyCode == Keys.Up && player.Location.Y > 0) playerPosAfterMov.Y -= 1;
      if (keyPressed.KeyCode == Keys.Right && player.Location.X < 17) playerPosAfterMov.X += 1;
      if (keyPressed.KeyCode == Keys.Left && player.Location.X > 0) playerPosAfterMov.X -= 1;

      bool canIMove = Player.WasThereACollision(playerPosAfterMov);

      if (!canIMove)
      {
        Item empty = new(0, "Empty", ' ', 0, new Point(player.Location.X, player.Location.Y));
        GameMap.Sectors[player.Location.X, player.Location.Y].Item = empty;
        sectors[player.Location.X, player.Location.Y].Text = GameMap.Sectors[player.Location.X, player.Location.Y].Item.Symbol.ToString();

        player.Location = playerPosAfterMov;
        GameMap.Sectors[player.Location.X, player.Location.Y].Item = player;
        sectors[player.Location.X, player.Location.Y].Text = GameMap.Sectors[player.Location.X, player.Location.Y].Item.Symbol.ToString();
      }
    }
  }
}