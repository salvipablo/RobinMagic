using RobinMagic.Inventorys;

namespace RobinMagic
{
  public partial class frmCrafting : Form
  {
    private readonly string[] strings = new string[4];  // Textos con descripcion para cada item a construir.
    private PictureBox[] pictureBoxes = new PictureBox[4];  // Array con los pictures (items necesarios para construir).
    private Label[] labels = new Label[4];  // Array con labels (cantidades de cada items necesarios para construir).

    private Crafting DataCrafting = new();
    private Dictionary<int, Item[]> ConstructionItems = new Dictionary<int, Item[]>(); // Diccionario con recetas para la construccion de items.

    private List<Item> ItemsNeededToBuild = new List<Item>(); // Listado con items necesarios para construir, con cantidades.
    private int IdItemToCreate;

    public frmCrafting()
    {
      InitializeComponent();

      strings[0] = "El palo de madera es un item que sirve para la construccion de otros items.\r\n\r\nAlgunos de los ejemplos de items que se pueden crear con este item, pueden ser hachas, palas, picos, etc.";
      strings[1] = "El hacha de madera es un item que le sirve para acelerar, la velocidad de talado.\r\n\r\nEl hacha de madera le sube la velocidad en 2 puntos.";
      strings[2] = "El pico de madera es un item que le sirve para acelerar la velocidad de minado.\r\n\r\nEl pico de madera le sube la velocidad en 3 puntos.";
      strings[3] = "La pala de madera es un item que le sirve para acelerar la velocidad de excavar.\r\n\r\nLa pala de madera le sube la velocidad en 1.5 puntos.";

      pictureBoxes[0] = picItem_1;
      pictureBoxes[1] = picItem_2;
      pictureBoxes[2] = picItem_3;
      pictureBoxes[3] = picItem_4;

      labels[0] = lblItem_1;
      labels[1] = lblItem_2;
      labels[2] = lblItem_3;
      labels[3] = lblItem_4;
    }

    private void CmbItem_TextChanged( object sender, EventArgs e )
    {
      int indexItemSelected = cmbItem.SelectedIndex;

      IdItemToCreate = GetIdItemToCreate(indexItemSelected);

      if ( indexItemSelected != -1 )
      {
        string textSelected = strings[indexItemSelected];
        lblDescription.Text = textSelected;

        if (ConstructionItems.Count == 0) ConstructionItems = DataCrafting.getItems();

        Item[] itemsNeeded = ConstructionItems[indexItemSelected + 1];

        ItemsNeededToBuild.Clear();

        for (int i = 0; i < itemsNeeded.Count(); i++)
        {
          pictureBoxes[i].Visible = true;
          pictureBoxes[i].ImageLocation = itemsNeeded[i].PathItem;

          labels[i].Visible = true;
          labels[i].Text = itemsNeeded[i].Amount.ToString();

          ItemsNeededToBuild.Add(new Item(itemsNeeded[i].Id, itemsNeeded[i].Amount));
        }
      }
    }

    private void Crafting(int quantityItemsCraft)
    {
      bool CanIBuild = false;

      foreach (Item item in ItemsNeededToBuild) CanIBuild = CheckIfICanBuild(item.Id, 0, item.Amount, 0);

      if (CanIBuild)
      {
        Inventory.StoreItemInInventory(IdItemToCreate, quantityItemsCraft, 0);
        foreach (Item item in ItemsNeededToBuild) Inventory.DiscountItem(item.Id, item.Amount);
      }
      else MessageBox.Show("No se puede crear item, porque no cuenta con los materiales necesarios.", "RobinMagic");
    }

    private bool CheckIfICanBuild(int idItem, int posArraySearch, int quantityOfThatItem, int HowMuchHaveInInventory)
    {
      bool returnValue = false;

      Item? item = null;

      int posItemFound = Inventory.Items.FindIndex(posArraySearch, x => x.Id.Equals(idItem));

      if (posItemFound != -1) item = Inventory.Items[posItemFound];

      if (posItemFound != -1 && item?.Amount < quantityOfThatItem)
      {
        HowMuchHaveInInventory += item.Amount;
        returnValue = CheckIfICanBuild(idItem, posItemFound + 1, quantityOfThatItem, HowMuchHaveInInventory);
      } else if (posItemFound != -1 && item?.Amount >= quantityOfThatItem) HowMuchHaveInInventory += item.Amount;

      if (HowMuchHaveInInventory >= quantityOfThatItem) returnValue = true;
      return returnValue;
    }

    private void btnCreateItems_Click(object sender, EventArgs e) { Crafting((int)nudAmount.Value); }

    private int GetIdItemToCreate(int idItemCmb)
    {
      if (idItemCmb == 0) return 11;  // Woodenstick.
      if (idItemCmb == 1) return 12;  // Axe.
      if (idItemCmb == 2) return 13;  // Pickaxe.
      if (idItemCmb == 3) return 14;  // Shovel.
      return 0;    
    }
  }
}
