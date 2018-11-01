
using System.Collections.Generic;
using GameServer.Models;
using GameServer.Strategy;

namespace GameServer.EnemyBuilder
{
    public class EnemyParty
    {
        private List<Entity> enemies;

        private Position position;

        public int id { get; private set; }

        public EnemyParty(int id, Position p)
        {
            this.id = id;
            this.position = p;
            enemies = new List<Entity>();
        }

        public void addEnemy(Entity enemy)
        {
            enemies.Add(enemy);
        }
    }
}


