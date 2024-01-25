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

    private Key( int id, string name, char symbol, int itemToObtain, Point point, bool keyFound ) : base(id, name, symbol, itemToObtain, point)
    {
      KeyFound = keyFound;
    }

    public static Key GetKey( int id, string name, char symbol, int itemToObtain, Point point, bool keyFound )
    {
      _key ??= new Key(id, name, symbol, itemToObtain, point, keyFound);
      return _key;
    }
  }
}
