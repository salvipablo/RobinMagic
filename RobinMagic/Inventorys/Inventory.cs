namespace RobinMagic.Inventorys
{
  internal static class Inventory
  {
    public static List<Item> Items = new();
    public static int NumberOfSlots = 10;
    public static int NumbersItemsCanBeStored = 30;

    public static void DiscountItem(int idDiscountItem, int amount)
    {
      int posItemFound = Items.FindIndex(0, x => x.Id.Equals(idDiscountItem));
    }

    public static void StoreItemInInventory(int idItemToSave, int amountToSave,int posArraySearch = 0)
    {
      Item itemToSave = GameManager.ReturnItem(idItemToSave, new Point(0, 0), 0);

      int posItemFound = Items.FindIndex(posArraySearch, x => x.Name!.Equals(itemToSave.Name));

      // Este caso se produce cuando no encuentra el item, dentro del inventario, y no tiene mas espacios libres.
      if (posItemFound == -1 && Items.Count == NumberOfSlots)
      {
        MessageBox.Show($"No hay espacios libres en el inventario");
        amountToSave = 0;
      }

      // Este caso se produce cuando no encuentra el item, dentro del inventario, y si tiene espacios libres.
      if (posItemFound == -1 && Items.Count < NumberOfSlots)
      {
        Items.Add(itemToSave);

        if (amountToSave <= NumbersItemsCanBeStored)
        {
          Items[^1].Amount = amountToSave;
          amountToSave = 0;
        }
        else
        {
          Items[^1].Amount = NumbersItemsCanBeStored;
          amountToSave -= NumbersItemsCanBeStored;
        }
      }

      // Este caso se produce cuando se encuentra el item. Y ese tiene espacio para almacenar.
      if (posItemFound > -1 && Items[posItemFound].Amount < NumbersItemsCanBeStored)
      {
        int howMuchSpace = NumbersItemsCanBeStored - Items[posItemFound].Amount;
        if (amountToSave > howMuchSpace)
        {
          Items[posItemFound].Amount = howMuchSpace;
          amountToSave -= howMuchSpace;
        } 
        else
        {
          Items[posItemFound].Amount += amountToSave;
          amountToSave = 0;
        }
      }

      posArraySearch = posItemFound == -1 ? 0 : posItemFound + 1;

      if (amountToSave > 0) StoreItemInInventory(idItemToSave, amountToSave, posArraySearch);
    }
  }
}
