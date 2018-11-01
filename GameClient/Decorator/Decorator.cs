

using System.Text;
using System.Drawing;
/**
* @(#) Decorator.cs
*/
namespace GameClient.Decorator
{
	public abstract class Decorator : MapComponent
	{
		public MapComponent mapComponent;

        public Decorator(MapComponent mapComponent)
        {
            this.mapComponent = mapComponent;
            this.currentMap = mapComponent.currentMap;
        }
    }
	
}
