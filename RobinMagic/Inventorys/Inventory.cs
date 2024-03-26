namespace RobinMagic.Inventorys
{
  internal static class Inventory
  {
    public static List<Item> Items = new();
    public static int NumberOfSlots = 10;
    public static int NumbersItemsCanBeStored = 30;

    public static void DiscountItem(int idDiscountItem, int amount)
    {
      int posItemFound = 0;
      int posArraySearch = 0;

      while (amount != 0)
      {
        posItemFound = Items.FindIndex(posArraySearch, x => x.Id.Equals(idDiscountItem));
        int HowMuchIsThePositionFound = Items[posItemFound].Amount;
        
        if (posItemFound != -1 && HowMuchIsThePositionFound < amount)
        {
          Items[posItemFound].Amount -= HowMuchIsThePositionFound;
          amount -= HowMuchIsThePositionFound;
          HowMuchIsThePositionFound = 0;

          Items[posItemFound] = GameManager.ReturnItem(0, new Point(0, 0), 0);
        }

        if (posItemFound != -1 && HowMuchIsThePositionFound >= amount)
        {
          Items[posItemFound].Amount -= amount;
          amount = 0;

          if (Items[posItemFound].Amount == 0) Items[posItemFound] = GameManager.ReturnItem(0, new Point(0, 0), 0);
        }

        posArraySearch = posItemFound + 1;
      }
    }

    public static Item GetItemByIdAndPosition(int idItem, int posArraySearch)
    {
      int posItemFound = Inventory.Items.FindIndex(posArraySearch, x => x.Id.Equals(idItem));
      return posItemFound == -1 ? GameManager.ReturnItem(0, new Point(0, 0), 0) : Items[posItemFound];
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
