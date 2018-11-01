

using System.Text;
/**
* @(#) EnemyDecorator.cs
*/
namespace ClassDiagram.GameClient
{
    class EnemyDecorator : Decorator
    {
        public EnemyDecorator(MapComponent mapComponent) : base(mapComponent)
        {
        }

        public override void draw(int x, int y)
        {
            StringBuilder currentTile = new StringBuilder(currentMap[x]);
            currentTile[y] = 'E';
            currentMap[x] = currentTile.ToString();
            mapComponent.draw(0, 0);
        }
    }

}
