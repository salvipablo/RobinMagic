
namespace RobinMagic.Items
{
  internal class Tree : Item
  {
    private float life = 6;
    public Tree( int id, string name, char symbol, int itemToObtain, Point point, float life ) : base(id, name, symbol, itemToObtain, point)
    {
      this.life = life;
    }

    public float GetLife() { return life; }

    public void SetLife(float lifeToTake )
    {
      this.life -= lifeToTake;
    }
  }
}
