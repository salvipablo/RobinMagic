

namespace RobinMagic.Items
{
  internal class RockFloor : Item
  {
    public RockFloor( int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life ) :
                                                                              base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life) { }

    // Aqui se podrian ver cosas especificas como el tipo de arbol, que items se obtienen de el. Que se puede fabricar, etc
  }
}
