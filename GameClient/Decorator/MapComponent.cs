using GameClient.Iterator;

namespace GameClient.Decorator
{
    public abstract class MapComponent
    {
        public Map2dArray currentMap = new Map2dArray();

        public MapHashTable dungeon = new MapHashTable();
        public abstract void draw(int x, int y);
        public abstract void drawDungeon(int x, int y);
    }
}