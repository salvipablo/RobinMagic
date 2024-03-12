using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinMagic
{
  internal class Key : Item
  {
    private static Key? _key;
    public bool KeyFound { get; set; }

    private Key(int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, bool keyFound, int amount, float life, string pathItem ) :
                                                                                base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life, pathItem)
    {
      KeyFound = keyFound;
    }

    public static Key GetKey(int id, string name, string symbol, int itemToObtain, int amountToObtain, Point point, bool keyFound, int amount, float life, string pathItem )
    {
      _key ??= new Key(id, name, symbol, itemToObtain, amountToObtain, point, keyFound, amount, life, pathItem);
      return _key;
    }
  }
}
