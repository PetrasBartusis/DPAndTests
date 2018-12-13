

using System.Text;
/**
* @(#) PlayerDecorator.cs
*/
namespace GameClient.Decorator
{
    public class PlayerDecorator : Decorator
    {
        public PlayerDecorator(MapComponent mapComponent) : base(mapComponent)
        {
        }

        public override void draw(int x, int y)
        {
            mapComponent.currentMap.map2DIterator.addEntity('P', x, y);
            mapComponent.draw(0, 0);
        }

        public override void drawDungeon(int x, int y)
        {
            mapComponent.dungeon.mapHashTableIterator.addEntity('P', x, y);
            mapComponent.drawDungeon(0, 0);
        }
    }

}
