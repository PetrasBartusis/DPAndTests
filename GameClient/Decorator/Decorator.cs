

using System.Text;
using System.Drawing;
/**
* @(#) Decorator.cs
*/
namespace ClassDiagram.GameClient
{
	abstract class Decorator : MapComponent
	{
		protected MapComponent mapComponent;

        public Decorator(MapComponent mapComponent)
        {
            this.mapComponent = mapComponent;
            this.currentMap = mapComponent.currentMap;
        }
    }
	
}
