

using System.Text;
/**
* @(#) PlayerDecorator.cs
*/
namespace ClassDiagram.GameClient
{
    class PlayerDecorator : Decorator
    {
        public PlayerDecorator(MapComponent mapComponent) : base(mapComponent)
        {
            
        }

        public override void draw(int x, int y)
        {
            StringBuilder currentTile = new StringBuilder(mapComponent.currentMap[x]);
            currentTile[y] = 'P';
            currentMap[x] = currentTile.ToString();
            mapComponent.draw(0, 0);
        }

    }

}
