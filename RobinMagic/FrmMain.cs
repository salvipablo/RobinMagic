using Microsoft.VisualBasic;
using RobinMagic.Inventorys;
using RobinMagic.Items;

namespace RobinMagic
{
  public partial class FrmMain : Form
  {
    private readonly int initialPositionScreenX = 10;
    private readonly int initialPositionScreenY = 10;
    private readonly int mapSectorSizeX = 30;
    private readonly int mapSectorSizeY = 30;
    private readonly Label[,] sectors = new Label[GameMap.Sectors.GetLongLength(0), GameMap.Sectors.GetLongLength(1)];
    private readonly Player player = Player.GetPlayer(1, "Pablo", "P1", 0, 0, new Point(6, 15), 1, 25, "");
    private readonly Key key = Key.GetKey(6, "Key", "K", 0, 1, new Point(15, 9), false, 1, 999, "");
    private Point TopLeftVertex;
    private Point WhatSectorMoveTo;

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

      for (int y = 0; y < 18; y++)
      {
        for (int x = 0; x < 18; x++)
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

      GameMap.FillMap(player!.Location.X, player.Location.Y);

      TopLeftVertex.X = ReturnTopLeftVertex(player!.Location).X;
      TopLeftVertex.Y = ReturnTopLeftVertex(player.Location).Y;

      WhatSectorMoveTo.X = player.Location.X - TopLeftVertex.X; 
      WhatSectorMoveTo.Y = player.Location.Y - TopLeftVertex.Y;

      ShowScreen();
      ShowInfoScreen();
    }

    #pragma warning disable CA1822 // Marcar miembros como static
    public Point ReturnTopLeftVertex(Point PosPlayer)
    {
      return new Point((PosPlayer.X / 18) * 18, (PosPlayer.Y / 18) * 18);
    }

    public void ShowScreen()
    {
      int ySectors = -1;
      int xSectors = -1;

      for (int y = TopLeftVertex.Y; y < TopLeftVertex.Y + 18; y++)
      {
        ySectors++;
        for (int x = TopLeftVertex.X; x < TopLeftVertex.X + 18; x++)
        {
          xSectors++;
          sectors[xSectors, ySectors].BackColor = GameMap.Sectors[x, y].Tile.Color;
          sectors[xSectors, ySectors].Text = GameMap.Sectors[x, y].Item.Symbol?.ToString();
        }

        xSectors = -1;
      }
    }

    private void FrmMain_KeyDown( object sender, KeyEventArgs e )
    {
      if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left) this.PlayerMove(e);
      if (e.KeyCode == Keys.L) this.InvestigateArea();
      if (e.KeyCode == Keys.Space) this.Hit();
      if (e.KeyCode == Keys.I) ShowInventory();
      if (e.KeyCode == Keys.C)
      {
        frmCasting frmCasting = new();
        frmCasting.Show();
      }
      if (e.KeyCode == Keys.D1) EquipItem(player.GetItems()[0]);
      if (e.KeyCode == Keys.D2) EquipItem(player.GetItems()[1]);
      if (e.KeyCode == Keys.D3) EquipItem(player.GetItems()[2]);
      if (e.KeyCode == Keys.D4) EquipItem(player.GetItems()[3]);
      if (e.KeyCode == Keys.D5) EquipItem(player.GetItems()[4]);
      if (e.KeyCode == Keys.D6) EquipItem(player.GetItems()[5]);

      // Actualizo la informacion de pantalla.
      ShowInfoScreen();

      // TODO: Eliminar esta linea es solo para la simulacion del inventario.
      if (e.KeyCode == Keys.S) StoreInInventory();
    }

    private void EquipItem(Item item)
    {
      if (player.ItemEquippedOnPlayer().Name != "Empty") player.ItemEquippedOnPlayer().UnequipItem(player);
      item.ToEquip(player);
    }

    private void Hit()
    {
      Item? objectFront = null;

      if (GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item.Symbol != " ")
      {
        objectFront = GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item;
      }

      if (objectFront != null)
      {
        float HowMuchLife = 0.5f;

        if (objectFront.Name == "Tree") HowMuchLife = player.GetAxeSpeed();
        if (objectFront.Name == "RockFloor") HowMuchLife = player.GetPickaxeSpeed();

        objectFront!.LoseLife(HowMuchLife);

        if (objectFront!.GetLife() <= 0f)
        {
          int idItemToObtain = GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item.ItemToObtain;

          int QuantityToStore = GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item.AmountToObtain;

          GameMap.Sectors[Player.GetItem().Location.X, Player.GetItem().Location.Y].Item =
                          GameManager.ReturnItem(idItemToObtain, new Point(Player.GetItem().Location.X, Player.GetItem().Location.Y), QuantityToStore);

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
      Point WhatSectorMoveToBefore = WhatSectorMoveTo;
      Point playerPosAfterMov = player!.Location;

      if (keyPressed.KeyCode == Keys.Down && player.Location.Y < GameMap.Sectors.GetLongLength(1) - 1) playerPosAfterMov.Y += 1;
      if (keyPressed.KeyCode == Keys.Up && player.Location.Y > 0) playerPosAfterMov.Y -= 1;
      if (keyPressed.KeyCode == Keys.Right && player.Location.X < GameMap.Sectors.GetLongLength(0) - 1) playerPosAfterMov.X += 1;
      if (keyPressed.KeyCode == Keys.Left && player.Location.X > 0) playerPosAfterMov.X -= 1;

      bool wasCollision = Player.WasThereACollision(playerPosAfterMov);

      if (!wasCollision)
      {
        if (keyPressed.KeyCode == Keys.Down && player.Location.Y < GameMap.Sectors.GetLongLength(1) - 1) WhatSectorMoveTo.Y += 1;
        if (keyPressed.KeyCode == Keys.Up && player.Location.Y > 0) WhatSectorMoveTo.Y -= 1;
        if (keyPressed.KeyCode == Keys.Right && player.Location.X < GameMap.Sectors.GetLongLength(0) - 1) WhatSectorMoveTo.X += 1;
        if (keyPressed.KeyCode == Keys.Left && player.Location.X > 0) WhatSectorMoveTo.X -= 1;

        Point TopLeftVertexTemp = new(0, 0)
        {
          X = ReturnTopLeftVertex(playerPosAfterMov).X,
          Y = ReturnTopLeftVertex(playerPosAfterMov).Y
        };

        if (TopLeftVertex.X != TopLeftVertexTemp.X || TopLeftVertex.Y != TopLeftVertexTemp.Y)
        {
          TopLeftVertex.X = ReturnTopLeftVertex(playerPosAfterMov).X;
          TopLeftVertex.Y = ReturnTopLeftVertex(playerPosAfterMov).Y;

          if (WhatSectorMoveTo.X > 17) WhatSectorMoveTo.X = 0;
          if (WhatSectorMoveTo.X < 0) WhatSectorMoveTo.X = 17;
          if (WhatSectorMoveTo.Y > 17) WhatSectorMoveTo.Y = 0;
          if (WhatSectorMoveTo.Y < 0) WhatSectorMoveTo.Y = 17;

          // Coloco item vacio donde esta el personaje.
          Item empty = GameManager.ReturnItem(0, new Point(player.Location.X, player.Location.Y), 0);
          GameMap.Sectors[player.Location.X, player.Location.Y].Item = empty;

          player.Location = playerPosAfterMov;

          // Coloco al personaje en el mapa
          GameMap.Sectors[player.Location.X, player.Location.Y].Item = player;
          ShowScreen();
        } 
        else
        {
          Item empty = GameManager.ReturnItem(0, new Point(player.Location.X, player.Location.Y), 0);
          GameMap.Sectors[player.Location.X, player.Location.Y].Item = empty;
          sectors[WhatSectorMoveToBefore.X, WhatSectorMoveToBefore.Y].Text = GameMap.Sectors[player.Location.X, player.Location.Y].Item.Symbol?.ToString();

          player.Location = playerPosAfterMov;

          // ACA VERIFICO SI LA POSICION DEL PLAYER ES IGUAL A LA DE UN ITEM QUE SE PUEDE JUNTAR, LLAMO A ALMACENAR
          if
          (
                GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Stone" ||
                GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Wood" ||
                GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Iron"
          )
          {
            Inventory.StoreItemInInventory(GameMap.Sectors[player.Location.X, player.Location.Y].Item.Id,
                                                      GameMap.Sectors[player.Location.X, player.Location.Y].Item.Amount);
          }

          if (GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Axe")
                                  player.AddItem(GameMap.Sectors[player.Location.X, player.Location.Y].Item);
          if (GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Pickaxe")
                                    player.AddItem(GameMap.Sectors[player.Location.X, player.Location.Y].Item);
          if (GameMap.Sectors[player.Location.X, player.Location.Y].Item.Name == "Shovel")
                                  player.AddItem(GameMap.Sectors[player.Location.X, player.Location.Y].Item);

          GameMap.Sectors[player.Location.X, player.Location.Y].Item = player;
          sectors[WhatSectorMoveTo.X, WhatSectorMoveTo.Y].Text = GameMap.Sectors[player.Location.X, player.Location.Y].Item.Symbol?.ToString();
        }
      }

      ShowInfoScreen();
    }

    private void ShowInfoScreen()
    {
      lblPosition.Text = $"Player Position: ({this.player!.Location.X}, {this.player.Location.Y})";
      lblItem.Text = Player.GetItem() == null ?  $"Item en frente:" : $"Item en frente: {Player.GetItem().Name}";

      if (player.Location.X == 4 && player.Location.Y == 5) lblWin.Visible = true;

      lblLife.Text = $"Vida: {player.GetLife()}";
      lblAxeSpeed.Text = $"Velocidad de Hacha: {player.GetAxeSpeed()}.";
      lblPickaxeSpeed.Text = $"Velocidad de Pico: {player.GetPickaxeSpeed()}.";
      lblEquipped.Text = $"Equipado con: {player.ItemEquippedOnPlayer().Name}.";
      lblShovelSpeed.Text = $"Velocidad de Pala: {player.GetShovelSpeed()}.";

      int pos = 0;
      foreach (var Item in player.GetItems())
      {
        if (Item.Name != null && pos == 0 && Item.Name == "Axe")
                  picItemsPlayer_1.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\axe.png";
        if (Item.Name != null && pos == 0 && Item.Name == "Pickaxe")
                  picItemsPlayer_1.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\pickaxe.png";
        if (Item.Name != null && pos == 0 && Item.Name == "Shovel")
                  picItemsPlayer_1.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\shovel.png";

        if (Item.Name != null && pos == 1 && Item.Name == "Axe")
            picItemsPlayer_2.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\axe.png";
        if (Item.Name != null && pos == 1 && Item.Name == "Pickaxe")
            picItemsPlayer_2.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\pickaxe.png";
        if (Item.Name != null && pos == 1 && Item.Name == "Shovel")
            picItemsPlayer_2.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\shovel.png";

        if (Item.Name != null && pos == 2 && Item.Name == "Axe")
          picItemsPlayer_3.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\axe.png";
        if (Item.Name != null && pos == 2 && Item.Name == "Pickaxe")
          picItemsPlayer_3.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\pickaxe.png";
        if (Item.Name != null && pos == 2 && Item.Name == "Shovel")
          picItemsPlayer_3.ImageLocation = "C:\\Users\\psalvi\\source\\repos\\RobinMagic\\RobinMagic\\images\\shovel.png";

        pos++;
      }
    }

    // TODO: Eliminar este metodo es solo para simular el almacenamiento en inventario
    #pragma warning disable CA1822 // Marcar miembros como static
    private void StoreInInventory()
    {
      try
      {
        int idMaterial = int.Parse(Interaction.InputBox("Ingrese ID de Material a almacenar:", "System"));
        int cantidad = int.Parse(Interaction.InputBox("Ingrese cantidad de Material a almacenar:", "System"));
        Inventory.StoreItemInInventory(idMaterial, cantidad, 0);
      }
      catch (Exception e)
      {
        MessageBox.Show($"No colocaste o ID de material, o cantidad a almacenar: {e.Message}");
      }
    }

    private void ShowInventory()
    {
      FrmInventory frmInventory = new();

      int i = 1;
      int QuantityItemsIninventory = Inventory.Items.Count;

      foreach (Control Component in frmInventory.flowLayoutPanel1.Controls)
      {
        if (i > QuantityItemsIninventory) { break; }

        if (Component is Panel)
        {
          foreach (Control Control in Component.Controls)
          {
            if (Control.Name == $"lblItem{i}") Control.Text = Inventory.Items[i - 1].Symbol?.ToString();
            if (Control.Name == $"lblItem{i}_C") Control.Text = Inventory.Items[i - 1].Amount.ToString();
          }
          i++;
        }
      }

      frmInventory.Show();
    }
  }
}