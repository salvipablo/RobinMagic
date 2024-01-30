

namespace RobinMagic.Items
{
  internal class Tree : Item
  {
    public Tree( int id, string name, char symbol, int itemToObtain, Point point, float life ) : base(id, name, symbol, itemToObtain, point, life) { }

    // Aqui se podrian ver cosas especificas como el tipo de arbol, que items se obtienen de el. Que se puede fabricar, etc
  }
}
