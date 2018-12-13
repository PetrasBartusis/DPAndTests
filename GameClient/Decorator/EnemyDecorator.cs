

using System.Text;
/**
* @(#) EnemyDecorator.cs
*/
namespace GameClient.Decorator
{
    public class EnemyDecorator : Decorator
    {
        public EnemyDecorator(MapComponent mapComponent) : base(mapComponent)
        {
        }

        public override void draw(int x, int y)
        {
            mapComponent.currentMap.map2DIterator.addEntity('E', x, y);
            mapComponent.draw(0, 0);
        }

        public override void drawDungeon(int x, int y)
        {
            mapComponent.dungeon.mapHashTableIterator.addEntity('E', x, y);
            mapComponent.drawDungeon(0, 0);
        }
    }

}
