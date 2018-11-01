namespace GameClient.Decorator
{
    public abstract class MapComponent
    {
        public string[] currentMap = { "GGGGG", "GGGGG", "GGGGG", "GGGGG", "GGGGG" };
        public abstract void draw(int x, int y);
    }
}