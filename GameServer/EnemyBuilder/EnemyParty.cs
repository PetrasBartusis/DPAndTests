namespace GameServer.EnemyBuilder
{
    public class EnemyParty
    {
        List<Entity> enemies { get; private set; }

        Position position { get; private set; }

        int id { get; private set; }

        public EnemyParty(int id, Position p)
        {
            this.id = id;
            this.position = p;
            enemies = new List<Entity>();
        }

        public void addEnemy(Entity enemy) => enemies.add(enemy);

    }
}


