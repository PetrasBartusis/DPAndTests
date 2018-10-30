/**
 * @(#) MapComponent.cs
 */

namespace ClassDiagram.GameClient
{
	public abstract class MapComponent
	{
        public string[] currentMap = { "GGGGG", "GGGGG", "GGGGG", "GGGGG", "GGGGG" };
        public abstract void draw(int x, int y);
	}
	
}
