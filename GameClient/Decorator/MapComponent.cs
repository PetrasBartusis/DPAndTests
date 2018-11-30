namespace GameClient.Decorator
{
    public abstract class MapComponent
    {
        public string[] currentMap = { "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG", "GGGGGGGGGG" };
        public abstract void draw(int x, int y);
    }
}