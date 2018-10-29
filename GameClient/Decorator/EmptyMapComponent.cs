/**
 * @(#) EmptyMapComponent.cs
 */

namespace ClassDiagram.GameClient
{
    public class EmptyMapComponent : MapComponent
    {
        public void draw()
        {
            Draw.RectangleFromTop(0, 0, 33, 15, System.ConsoleColor.Green, useDoubleLines: true);
        }
    }

}
