

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
            StringBuilder currentTile = new StringBuilder(mapComponent.currentMap[y]);
            currentTile[x] = 'P';
            currentMap[y] = currentTile.ToString();
            mapComponent.draw(0, 0);
        }

    }

}
