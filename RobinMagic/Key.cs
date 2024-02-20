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

    private Key(int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, bool keyFound, int amount, float life) :
                                                                                base(id, name, symbol, itemToObtain, amountToObtain, point, amount, life)
    {
      KeyFound = keyFound;
    }

    public static Key GetKey(int id, string name, char symbol, int itemToObtain, int amountToObtain, Point point, bool keyFound, int amount, float life)
    {
      _key ??= new Key(id, name, symbol, itemToObtain, amountToObtain, point, keyFound, amount, life);
      return _key;
    }
  }
}
