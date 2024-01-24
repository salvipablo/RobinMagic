using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinMagic
{
  internal class Player : Item
  {
    private static Player? _player;

    public Player(int id, string name, char symbol, int itemToObtain, Point point) : base(id, name, symbol, itemToObtain, point)
    {
    }

    public static Player GetPlayer(int id, string name, char symbol, int itemToObtain, Point point)
    {
      _player ??= new Player(id, name, symbol, itemToObtain, point);
      return _player;
    }

    public static bool WasThereACollision(Point newPlayerPos)
    {
      return GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Item.Symbol != ' ' || GameMap.Sectors[newPlayerPos.X, newPlayerPos.Y].Tile.Material == "Ocean"; 
    }
  }
}
