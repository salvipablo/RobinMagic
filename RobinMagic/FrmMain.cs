using Microsoft.VisualBasic;
using RobinMagic.Inventorys;

namespace RobinMagic
{
  public partial class FrmMain : Form
  {
    private readonly int initialPositionScreenX = 10;
    private readonly int initialPositionScreenY = 10;
    private readonly int mapSectorSizeX = 30;
    private readonly int mapSectorSizeY = 30;
    private readonly Label[,] sectors = new Label[GameMap.Sectors.GetLongLength(0), GameMap.Sectors.GetLongLength(1)];
    private readonly Item? player = Player.GetPlayer(1, "Pablo", '1', 0, 0, new Point(1, 1), 1, 999);
    private readonly Key key = Key.GetKey(6, "Key", 'K', 0, 1, new Point(15, 9), false, 1, 999);

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

    private void FrmMain_KeyDown( object sender, KeyEventArgs e )
    {
      if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) this.PlayerMove(e);
      if (e.KeyCode == Keys.I) this.InvestigateArea();
      if (e.KeyCode == Keys.Space) this.Hit();
      if (e.KeyCode == Keys.I) ShowInventory();

      // TODO: Eliminar esta linea es solo para la simulacion del inventario.
      if (e.KeyCode == Keys.S) StoreInInventory();
    }

    private void Hit()
    {
      Item? objectFront = null;

      if (GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item.Symbol != ' ')
      {
        objectFront = GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item;
      }

      if (objectFront != null)
      {
        objectFront!.LoseLife(0.5f);

        if (objectFront!.GetLife() == 0)
        {
          int idItemToObtain = GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item.ItemToObtain;

          int QuantityToStore = GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item.AmountToObtain;

          GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item =
                          GameMap.ReturnItem(idItemToObtain, new Point(Player.GetItem().Location.X, Player.GetItem().Location.Y), QuantityToStore);

          this.ShowScreen();
        }
      }
    }

    private void InvestigateArea()
    {
      if (player!.Location.X + 1 == key.Location.X && player.Location.Y == key.Location.Y) key.KeyFound = true;
      if (player.Location.X - 1 == key.Location.X && player.Location.Y == key.Location.Y) key.KeyFound = true;
      if (player.Location.X == key.Location.X && player.Location.Y + 1 == key.Location.Y) key.KeyFound = true;
      if (player.Location.X == key.Location.X && player.Location.Y - 1 == key.Location.Y) key.KeyFound = true;

      if (key.KeyFound == true)
      {
        Player.SetIHaveKey();
        GameMap.PlaceKey(key);
        this.ShowScreen();
      }
    }

    private void PlayerMove( KeyEventArgs keyPressed )
    {
      Point playerPosAfterMov = player!.Location;

      if (keyPressed.KeyCode == Keys.Down && player.Location.Y < 17) playerPosAfterMov.Y += 1;
      if (keyPressed.KeyCode == Keys.Up && player.Location.Y > 0) playerPosAfterMov.Y -= 1;
      if (keyPressed.KeyCode == Keys.Right && player.Location.X < 17) playerPosAfterMov.X += 1;
      if (keyPressed.KeyCode == Keys.Left && player.Location.X > 0) playerPosAfterMov.X -= 1;

      bool canIMove = Player.WasThereACollision(playerPosAfterMov);

      if (!canIMove)
      {
        Item empty = GameMap.ReturnItem(0, new Point(player.Location.X, player.Location.Y), 0);
        GameMap.Sectors[player.Location.X, player.Location.Y].Item = empty;
        sectors[player.Location.X, player.Location.Y].Text = GameMap.Sectors[player.Location.X, player.Location.Y].Item.Symbol.ToString();

        player.Location = playerPosAfterMov;

        // ACA VERIFICO SI LA POSICION DEL PLAYER ES IGUAL A LA DE UN ITEM QUE SE PUEDE JUNTAR, LLAMO A ALMACENAR
        if (GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Stone" ||
                                            GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Wood")
        {
          Inventory.StoreItemInInventory(GameMap.Sectors[player.Location.X, player.Location.Y].Item.Id,
                                                    GameMap.Sectors[player.Location.X, player.Location.Y].Item.Amount);
        }

        GameMap.Sectors[player.Location.X, player.Location.Y].Item = player;
        sectors[player.Location.X, player.Location.Y].Text = GameMap.Sectors[player.Location.X, player.Location.Y].Item.Symbol.ToString();
      }

      ShowInfoScreen();
    }

    private void ShowInfoScreen()
    {
      lblPosition.Text = $"Player Position: ({this.player!.Location.X}, {this.player.Location.Y})";
      lblItem.Text = $"Item en frente: {Player.GetItem().Name}";

      if (player.Location.X == 4 && player.Location.Y == 5)
      {
        lblWin.Visible = true;
      }
    }

    // TODO: Eliminar este metodo es solo para simular el almacenamiento en inventario
    #pragma warning disable CA1822 // Marcar miembros como static
    private void StoreInInventory()
    {
      int idMaterial = int.Parse(Interaction.InputBox("Ingrese ID de Material a almacenar:", "System"));
      int cantidad = int.Parse(Interaction.InputBox("Ingrese cantidad de Material a almacenar:", "System"));
      Inventory.StoreItemInInventory(idMaterial, cantidad, 0);
    }

    private void ShowInventory()
    {
      FrmInventory frmInventory = new();

      int i = 1;
      int QuantityItemsIninventory = Inventory.Items.Count;

      foreach (Control Component in frmInventory.flowLayoutPanel1.Controls)
      {
        if (Component is Panel)
        {
          foreach (Control Control in Component.Controls)
          {
            if (Control.Name == $"lblItem{i}") Control.Text = Inventory.Items[i - 1].Symbol.ToString();
            if (Control.Name == $"lblItem{i}_C") Control.Text = Inventory.Items[i - 1].Amount.ToString();
          }
          i++;

          if (i > QuantityItemsIninventory) { break; }
        }
      }

      frmInventory.Show();
    }
  }
}