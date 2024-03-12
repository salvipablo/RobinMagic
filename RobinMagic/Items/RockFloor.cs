

namespace RobinMagic.Items
{
  internal class RockFloor : Item
  {
    public RockFloor( int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, int amount, float life, string pathItem ) :
                                                                              base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem) { }

    // Aqui se podrian ver cosas especificas como el tipo de arbol, que items se obtienen de el. Que se puede fabricar, etc
  }
}
